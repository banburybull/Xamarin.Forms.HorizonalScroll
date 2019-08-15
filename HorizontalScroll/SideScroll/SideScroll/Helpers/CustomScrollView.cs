using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace SideScroll.Helpers
{
    public class CustomScrollView : ScrollView
    {
        IList<object> templatedItems;

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(CustomScrollView), default(IEnumerable),
                                    BindingMode.Default, null, new BindableProperty.BindingPropertyChangedDelegate(HandleBindingPropertyChangedDelegate));

        private static object HandleBindingPropertyChangedDelegate(BindableObject bindable, object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(CustomScrollView), default(DataTemplate));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public event EventHandler<ItemTappedEventArgs> ItemSelected;

        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem", typeof(object), typeof(CustomScrollView), null, BindingMode.OneWayToSource,
    propertyChanged: OnSelectedItemChanged);

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            IList<object> cells = ((CustomScrollView)bindable).templatedItems;
            ((CustomScrollView)bindable).ItemSelected?.Invoke(bindable, new ItemTappedEventArgs(newValue, cells.IndexOf(newValue)));
        }

        public static readonly BindableProperty SelectedCommandProperty =
            BindableProperty.Create("SelectedCommand", typeof(ICommand), typeof(CustomScrollView), null);

        public ICommand SelectedCommand
        {
            get { return (ICommand)GetValue(SelectedCommandProperty); }
            set { SetValue(SelectedCommandProperty, value); }
        }

        public static readonly BindableProperty SelectedCommandParameterProperty =
            BindableProperty.Create("SelectedCommandParameter", typeof(object), typeof(CustomScrollView), null);

        public object SelectedCommandParameter
        {
            get { return GetValue(SelectedCommandParameterProperty); }
            set { SetValue(SelectedCommandParameterProperty, value); }
        }

        static void HandleBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            var isOldObservable = oldValue?.GetType().GetTypeInfo().ImplementedInterfaces.Any(i => i == typeof(INotifyCollectionChanged));
            var isNewObservable = newValue?.GetType().GetTypeInfo().ImplementedInterfaces.Any(i => i == typeof(INotifyCollectionChanged));

            var tl = (CustomScrollView)bindable;
            if (isOldObservable.GetValueOrDefault(false))
            {
                ((INotifyCollectionChanged)oldValue).CollectionChanged -= tl.HandleCollectionChanged;
            }

            if (isNewObservable.GetValueOrDefault(false))
            {
                ((INotifyCollectionChanged)newValue).CollectionChanged += tl.HandleCollectionChanged;
            }

            if (oldValue != newValue)
            {
                tl.Render();
            }
        }

        private void HandleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Render();
        }

        public void Render()
        {
            if (ItemTemplate == null || ItemsSource == null)
            {
                Content = null;
                return;
            }

            templatedItems = new List<object>();

            var layout = new StackLayout();
            layout.Orientation = Orientation == ScrollOrientation.Vertical ? StackOrientation.Vertical : StackOrientation.Horizontal;
            
            foreach (var item in ItemsSource)
            {
                var command = SelectedCommand ?? new Command((obj) =>
                {
                    var args = new ItemTappedEventArgs(ItemsSource, item);
                    SelectedItem = item;
                    ItemSelected?.Invoke(this, args);
                });
                var commandParameter = SelectedCommandParameter ?? item;

                var viewCell = ItemTemplate.CreateContent() as ViewCell;
                viewCell.View.BindingContext = item;
                viewCell.View.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = command,
                    CommandParameter = commandParameter,
                    NumberOfTapsRequired = 1
                });

                layout.Children.Add(viewCell.View);
                templatedItems.Add(viewCell.View);
            }

            Content = layout;
        }
    }
}

