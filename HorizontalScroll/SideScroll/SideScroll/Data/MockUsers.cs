using SideScroll.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;
using System.IO;

namespace SideScroll.Data
{
    public class MockUsers
    {
        public List<UserRecord> GetUsers()
        {
            var result = new List<UserRecord>();

            result.Add(new UserRecord() { FullName = "User One", DisplayPhoto = GetPhoto() });
            result.Add(new UserRecord() { FullName = "User Two", DisplayPhoto = GetPhoto() });
            result.Add(new UserRecord() { FullName = "User Three", DisplayPhoto = GetPhoto() });
            result.Add(new UserRecord() { FullName = "User Four", DisplayPhoto = GetPhoto() });
            result.Add(new UserRecord() { FullName = "User Five", DisplayPhoto = GetPhoto() });
            result.Add(new UserRecord() { FullName = "User Six", DisplayPhoto = GetPhoto() });
            result.Add(new UserRecord() { FullName = "User Seven", DisplayPhoto = GetPhoto() });
            result.Add(new UserRecord() { FullName = "User Eight", DisplayPhoto = GetPhoto() });
            result.Add(new UserRecord() { FullName = "User Nine", DisplayPhoto = GetPhoto() });
            result.Add(new UserRecord() { FullName = "User Ten", DisplayPhoto = GetPhoto() });

            return result;
        }


        public ImageSource GetPhoto()
        {
            var img = new CircleImage
            {
                BorderColor = Color.Navy,
                BorderThickness = 3,
                HeightRequest = 150,
                WidthRequest = 150,
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Center
            };

            img.Source = ImageSource.FromStream(() => new MemoryStream(DefaultImage()));          

            return img.Source;
        }
        private byte[] DefaultImage()
        {
            var base64img = "iVBORw0KGgoAAAANSUhEUgAAAIEAAACBCAYAAADnoNlQAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAGXRFWHRTb2Z0d2Fy" +
                "ZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAGi5JREFUeNrsXXuwJFdZ/053z+s+Z9+72ST3BoirCOyNscpIBbJqFLRKsiKWWv7hVoFAKeKCWhQomlIERavYWFoU" +
                "GnG11NICZaNoQWHBRYGitNSbmCCPQHbz2L27ye59zHumu4/fdx7dp3t6Hnvv3LnTu32S3jPTM7enu7/f+X2/7zuPZpxzyMrNXazsFmQlA0FWwLlZLvTIh774" +
                "U41m42c7budu4LzYardmLWYBsxiU8gV4xw/dDXnH9lc3640Xqq1vXm14D33qDXd+9Ga4N+xG1gTHHn785LX1q++tVivf1e60w4tmTNKgAsErbj8MP/zyFy" +
                "EILCjYFji0WRZcrTX50+vNx57ZaP3iZ97w4n/PQJAu459qtprvv/L86hFs8RHDJ4Hg5N3fAbftm4WibUMhZ0MeQZBTQMBd4OD3vnmtdvkbL9ROf+JHF/8" +
                "2A8FkG/8EVmc3KxsLl59fjV5oDxDMTRXhAQRBIWdByXEEGxRzDhQcDQQmNhu/i5iAr1yuPPfUWuNHHnnd4mMZCCbL+GWsHsTtl1avXIJKdbP7QnuA4DvR" +
                "FRw7sl8YvuRIJijiVnAkIxAocgQEfG3j31n4uu368D8XNz760fuPvjEDwWQAYBGrc7gdRwaAOAMMAsE9x+6A2VIepvM5KDoSAAIQOQKALUCQtxQrKGYgM" +
                "NAhvnql+q1//uqVu7/2ppetZyDYPQAsYbWM23y9UYdnLz4dMfYgEMxNTcGdtxzE6CCPRrexdmAKASCYgN4TIBwFBqUTiBVssaF7wMNcWGtsrFZax//s/l" +
                "suZHmCXQSA73vIAJeu+xjlmRmot12otdpQa3ew7sga9zVwq7c9sTU6HjRxa7ketD0fOj4H1/fBw/r2PaX5Ow9M/98b//XiQpYn2CUA0Pu1jTXodDrXfZx" +
                "rlRpwZAW0ZWTzgppj7YjXPMeDz/P0HlnBp8jBB9hTzJUICHhet6TRNTgpBEBZaQABAGKBtfW1LR2r3mxg627Dntk5mJ8qSSP70thcgMDGWoOEg5fDGrj4" +
                "jJyow5FILXyPfqGMQHj9yw5TxHB75g52vpzFLaBeYgECwlaLj7R+bbMCl9c3hFsg+ieXUGm50lXoDd1Bo602V7oI6R7INUj3cHu5dNvb/u3ypzIQ7CwLn" +
                "MbqAXPf5ubGSI7darfh4tU1WKvVhfFpqyoAaG1Q6+BrBQYCQAtDxSZqhBbpBARDBynixfumXvPmz176ycwd7GwuICjVWgU6bmekv7NeraEIdGH/3Kygf" +
                "O5D4A58dA8+DzVE6B7Qbdi+cA8YWcJCufTn+Kd/lzHBiEun035Y64AQBNUd+a0WisxLaxuwXm8i7YdsUBOMINlAMoIvWKGpooe2cg8zBbv0M5969nczE" +
                "IywHH3oy69oNBs/Ht/faNR39HfXqnV4vlIPtAEBoq7dgwZCx5chJLkGV7oG2lYrzbcp9srcwSiK63b+2LKieCU3MGpXkFSaKBKvbFRh3+w0Ur9yDcCMS" +
                "MJWIaUKIUHue77Wnsavn1RCNgPBNrXAYrvTvrdYKI6VBSIRBBr4arUBLif/n1cAUIaHUC8QGDyfwYVaQ4jGcin3vjSAYOLdAbb2nyaDO3YUr61Wc+znU" +
                "mm0UCe0pRtwQ5dQVy6hodzD46sVuGPvFLz6jr1HVc9mxgTbouNm881U29SxH6Hp1u6cD+oCvyETRtT6OYTRA2UY0Q2IcPFVd+wVaWUsp0BmNzMQbNUVt" +
                "NrNxUQFvwtMEGgUFH6bTVeGkKQPfKkPKGl0/lodjh2YBuqi2juVA6ULMnewjXICo4JkP013fheLh78vIwY/cA0v1OQQtsOzBWQD2cF0cCY/r/o6MhBsFQ" +
                "TtBNrfTRaIAoGL/IAME30Bgv3TBdnTKNLJAHMFwQYnMhBssdTq1Xv1a9txIq1wUgrpADI6sQINNnFsJiKDtupP2D8tQDDRTDDRmgBDwxcHJ2pP7qkqAQh5" +
                "BECHAODxgA1mCuK8FzMm2JooXHJ7jBFwx5Ak2horgDC+2FwafCKziFjuy5hga6XcKwzcygCScTECAUC4A6z/4+l1+Na1Okx6mWh34HsepK1QmEggWLm4Kc" +
                "YkpKFMtDBs7VJCaFs6Bn3C5WorAoBWqwWTnDlMRQdSvPNokgvlB8xcxsXLz0GpOAWFQiFzB9spuVwe0liuvLAKlOeg+Q1Yzmfu4DrLtbWrL4EUl0o1HPVU" +
                "KBTha296WQaC6xZYnjuTVgB4KGhrjWpqzjdbpGIHSrPVSNX5phIEuVxussPElIW2EwuCer32ZE816+TSBVrHeSIDwVZyBL/1uk/eKO7Bsmw3A8GIS3GCY+" +
                "7E8y0Wv5KBYPQtK0XnSusaOF/PQLDF4jjO5V6fFfLpYIO8PM+VDARbL2Kad9JIIstOBxuUCqUMBNuk/cd7fTZVnEoJE+Trk5wtnHgQtNutL0x2roANER7m" +
                "v5jlCbZXiEbF2C3Xc1OXK7BRwCITfCkDwTYK/8Abljnnom/Wc6MgmCpNrjvwFGALcurcuQwE248QviZvrJe6CAHPj/TASgaC7ZdP0z9JM5ALsUmqY1cECc" +
                "vlmWAtFaeWU5HLmPQTdF33L7HykwaXTuJoHV96LzFE3rbtj2UgGIV//Z3XrzBgjY6xSvmkhIlJTKAX0SoWS6nQA2lxB9SiRJjVaje73MGkpZD1HMm8k/uv" +
                "tKxpmAoQMMv6bZk3SGCDCYsSCAQ0pjCfL/wVpKSkAgSVX3/NF5B619oJLmFmendGoSW5Ai5WMuE6kXU2A8GISy6X/yStDBHXBqVdYoJkPeCr0LD4mTQtb5s" +
                "aEDiO815aX74dixJyTm5XQsVeTCC6jh3nbyBFJTUgWH3nvRfyufwTnu+CSiIGZW52bjKYAM/Ltp0GssDZDAQ7VErF0gcwXOzKHs5Mz44XAD06jpQeOAcpK" +
                "6kCwTffetdfO07uWnyRinG7hF6ugPZjZPDBDAQ7XPL5/B+AUuG75RJYwtxIPCPSA4+loa8g9SCwLfvD6HfrcRDMz86Lrtux3DSWfNsc2/kQpLCkDgQUeqH" +
                "6/v2uC0EATI8jZ8CS3QHqhBfSJghTCwJVziD1dj3oYN/e/bvGAgiMh1N6L9MJApWIORPfTwJxdmZntUGPtRIquP1eBoLxA+FBrB4dLxuwruV1VfmNND8bM" +
                "e2zkmnJ2I1xsYGDAEjQA59HAJxJ801MNQjUUO7T8f0H9x8c+RI3Fho/HxvOxrlPOexTKW9I6V+fQCnyh+KRwt49o3ULScmozcrmZyd9TsFNAQIFhNPNZi" +
                "OyMsSe+T0wNyK3QAwQ1wL0/KVra1c/fiPcvxtmpZLnLj1biS95d+jgkW0DgdZUjj91hX6HHstbLJbcDAQTUti7P77k+d7BZ557GpKAcOjA4a0BAHXFzFQ" +
                "0ASWWpbv0rBaISxkIJqeckgbyIAkIc7PzcPjgLT0TPYkAQPqfm5uPRAMEgGcuPi2Gvzt2Oh5ocTOB4GRoqGQg0DC0225doO7ogQejMLM8V46ARgOAZkgTM" +
                "By59P7C/Ps/s5SBYPddAYWIC1HKlkDYrGx0GffokdvgwL5DiXMZKQycmZnFyGJfJMQkQGkA6OMYDHE69fcw3huXMgCcAOMJ6kmFBpwcRl2QlDcgWnddVw4" +
                "RQaMWE8JAigJWr1wK5hPQcWiZWn08BYZ3bLznB89kIBi/8R+EIZ8jQHkDSiCRNhi2EEAuo/HrsecvTk9NR+Y6aEbAmlLYD66/+/5zGQh2zvBl5fuJfo8P/D" +
                "4aJ35tZDwad0D6IGmUMvl9egg3tX6qkxJGpCn00HI9migGhgtYncH67LV3ff96BoLRGP+kMv7JfrS/lUJGtRWtN1utgPKTowVHAAhAPg5X1MYwtwQwUPUX" +
                "DNi5q+/6vnMZCHbR8EmMcN35AgUAZjGxZAaX62ZEGKEnGMQoFLhAYMD67Au/emIlA0GPZA/Ix8bR9sAk3SCaXTyP4aIwqvxfPB2VXuh7x30ugJEIBtB/F9" +
                "QX8MNlfHnuyq+8+txNC4KY0U+MmuZHVfK5vAgZKV8gjcrA7ElWWJBsIGpf7PSNeREJIBCRiI5IsH5EgWJ59Z33rtyQILDe8/dk8CX8HVHDLj8ZTBjToPTka" +
                "MISE11JM5CZaHQxM1p3YEQDDMExtYvQzKD29wGBWV8gMODvLOO7lYunX7mSKhAUf/OfFn3OF/F4J3BbBHoN/L6AMidEe4i5AcKoTHv2YPoYRQ/5XE4kkqj" +
                "1i1wAk+MKSQ+I/2I+3ziyusZkEJh1HxBEwIY1ZbuQJdgKfiDqZ97+Peu7CoJ9H/zcEiriMm6iRvpbQsOXue8LY/umUOJRPzkpIBAAEAZmyriWMjhT+63A6A" +
                "EQgr9j4aYFAmiDaaEIETBEQMD0e7rx9F4JjN4gSHApgi0QFGyFWAPr8xd+4bvP7ygIbjnzpQc93z/le94C+ToKi/RGPlAYXryefBBIameGoS2RKh4OCEx9Lr" +
                "/DtD4wXAPX1xlohIBrQregQBA4pFBYaCQNAkEvFvk8o+csISgUSNa/9da7lrcFgoU/+s+y53vLaOzjFBmVS3nIO4546GOz40Kj7YqHO2gQiGQLl7EzLeFGTz" +
                "fteJ2BIBgnONQ0sYhxNRBChrACl2ECJQSCJWwVAMHShpJ2DHSBvDjD5QTCIapG6DssCgYd1mr9on9gAAiSawnWR7A+8+RbjieCol8H0pm8Yx3/9kNluHvhEB" +
                "wpz0Ah54gb0tuYPKBOElWiowVC+kyctMHYuOkguJkGmYM5zVSdbfiJigwsbXCmGYSJmmY+CbBololv+H1baY5en4e1HXkfYS7Gtnq/KOz+3J1/8tipoZngjg" +
                "//98kc45+490UHgdr4ZrMDlWYbqi0Xaq0O1NudCBNIReyLTBrVdKL1ek093TyWUAli7LBlmDH3pOmBgBUMprAkFajvCnhEWnt4qTwIHTQzBNGEEVZEr9y4QY" +
                "GfYaGI0LkKDWA8j9vKMgX+fLUFLWTqBCZQtXjxY9948ysi+Ylez0U889qXHhUH2Wh2+tIr0xet/BmdXa1RU7SmXR0Lrk+II+PrwManB/TvRmkVovG/EdODwQ" +
                "IQOVWmgCABEG2d2mDyOFwZTxhOX7s2PjPOTLkOfZ5cnV9wa9U58ghvSR3xysX9MF/CqAbBm7MtuFxpwnObDXjy+SpcqXYt8XP22/70fxe//nMvX+8Jgpd85N" +
                "ETt5ZLC3um8rBeb/ePtyG8UIZX5Lptetx9cBMNrRPehKQGz8foBsK3hhqPtJRul6HREgOOSdH6WpPAxw1QBMbngbnl5etj8yDgjACPRcDMI3ueulaDY4fmI" +
                "GfJZzXvn87D4bki3HP7XlittOCLT12Fp9eDcbiUmKNOuAf7aYJTB2cKg+9o7EJpLSHRN8/MVmS0MkPxigvhJgb4xOuBkClMIETDuTC1zKLhZGSzut5b8X2W/" +
                "p7V9ffBhFgW/uY1bKwt18NNPqy74contzc7HhxAQPzE8aPwA3ceiNh4kDA8eev8VD+JHUWmWEeoDR1jAerwxkVkb9gyElrmWDKFEPpUSDQu6zIuxJiCJXy3K" +
                "wwNjJa0L3mzYjmI/sBhketZa3SgLQzvya0jAdD0uABEE7eXH5mD1x47GAR/6BJOJILg2MOPU1p3frboDO1nWwEDRA3LAspTlMuZIrkwihgXA4xaD7CuV31+O" +
                "WK0ZFAAC4GVDBIDtBDWGjAbTVe2fAKCxwUQGhoUCIaG2l60bxpeeihY2udkLyYQgyb3TxeGcgY+9xAAndBndrXwUOFKUcS7w8KU6oGthGpJ1G66oETjx43e" +
                "BQ55jDZGYpTDEYb3lFvo+MJFNIWLkCxx19H5iK2ThOHSYD2gIhiggRjNSA5eJzmCcE+pQt5HCN4IemBbDMVi94LHmSR643jk/unz4SjiOzBbzImQ3cPN8S" +
                "3wbSbeO8jCnnjvo3i0YLbgQKXl3teTCYqONZQYjK4nyEG7f32TeCQGNNUxi13IjaMHRpLWZt2aIvaNhKQRCnOMCjrIBG1s+WIjZlACsaVcQ7MjGWE6b5vuv" +
                "4sJynPF3EBXQC1dLjErY2Ly91zHgb46ed9Ih4adZwoYfPx6AMatB0Z09sxgAd4Nbs0engABsgC2YUf04yALYJRhCxbA17aFDOHjFml/5SQmOE5Jh0GlYS4" +
                "0zWMmZZEOdiMu4LubH2C7qwdGA4huBtIdWa5iApfYAF+3PbUpViAmkMwQAdNSv4xhz0J/32i2YwkyFu0z1/ZlNII31AtGYHDT64Ht6Yg4KzBwad1n6rxDW" +
                "5AG8BkTaXwHNQCxAjEE9QJbPJKiLyeCYH5AeOgh0riR947+a3adaoHgRwCUKj0A49MD143q2E2kPk1yB7aSYhZTLoGW2mXSLfjoFii1XMhFp9k7Ro7ghAR" +
                "Bf3fQEUvKGjxv+IGgZav+Au5ziPoJP116gO2mHri+Qu5AAIBavHgtIwMfd/iWrIkNCCAFm8EwHUh9maDbn3MAs5cw0pPWQwDsgh6A1OqB/iWvRB+1fJtYw" +
                "BL6XIDCV/t95ks2sEgowvZA0DEXl+bJNtVOwTepYgL0AEu5HujVgmzqOEJXIKZF0JhILveJ10wN9rGYAgkTeYRtgYDHIgIeGzWjh1vzLh7gmR4YFQRi99A" +
                "WrVuG5ET9osULIHChFSxLvveFOJSg2BYIkmmdGz4fulo+511QyPTAlozPE6wh772vGqblycBfKDSPAICg8CUrcJnGUdPotgQC+ZcFx4FKZMQM70pmCEEYM" +
                "XdsVfJMD1xXo+s16IoHA3e4SAJRRMCFIFcZe9o8KRbpM4tbAhS+35sJzg9zSnqcnZnn1kOtocvovEsLZHpgKLP3bShmg5J5gND5MpCjvslOtJtavuXLBTg" +
                "kEKBLEwQZw6HX4+MJnsCk+oQOI65cwrhHFqdBD3BjDGY4XD+JDbonv+o+G9IDouOIal/SPb12fdnq9WuRNsa60nL7uwMaU7hvOt/zpB3Hjl9CxMCBRlTJo" +
                "nD8wBgBMBF6gCeKuKFYINFl8q6GFw5zlwxgDkWjLC5jvjxr5SroddOTHUoDQNB/aT7bYomI1Fesp2CFbmIS8wN68CaPzBMUworJPXrAHxcpWhb43hGR/YD" +
                "7wGMjkpM/tw1XwIw8ojS6OadF9yVIJjBYbzkJBLTKxsKgVpZDcdhqt7uMzIdyIePWA2EyiwMLB71ymWo1+zTkeAgm4231XjQgKzzmIH89FDsMbBQ8OiiP9" +
                "wsVdQMMRznTS09NBaBUsuaKXnomDoLzg0BApVTICxCYQiWYfpUYxsDAmcCj1wN62hfr0gPhMP5wyZlg+RkIW76cHURAoNqXgTa7HjaLjq/kvT/qCRTe47vB" +
                "OQdg8KXqZ6YA5pHrnis6olvg2Y3gmdPrie6AuhwHpimdXN8GnzgXcYz5AW3YMOzT58IENQZpNdXfEQIB1PB5NZkGKcASaVdLsIZEjjncmw/2cJxHZ4vw7tb" +
                "RCw+8qxUxY4yOFIFdk1EgHNthtnsaaHrPwl54YnUzAIF+aFccBCtXKq37Brc0ufZ/JyYwJqIY4wl1tCLnDWqVLYGgqVTOC1ALTIhEiiWMTWEVAYWrmjKhcr" +
                "BsVztNbNyx6YXhCieDPGZksgbr6pMJp2+xnml70/jTeQe+d3EvHJ2Xy/MlTEbpAsHQc99pFa9OtQMTWVhM2QdhK1NxNNlVsgH1cIh0N6VXxQe+amFMAIFy7" +
                "kzF2bwP2bMEQ/Ah6sTT17OROIeuSVqGDogAK+bvaSbSsQOzYoRxwbGEMCTwN0Km/3w/TTC036X1f3138hb6DmYDmTN+5d011gaQuVTKrnP1uHsfrW6R37d8" +
                "wRieeKkGcTAG0DX7Z5CZe4DCnFrYo466VzWMT7kvFqdls1VjxHBbuQS3zJegiAKeRhvJMYk+2B5LZKMuEFyutoa+2bQCaMetTiAV8PDG8XA+ICj/TpNIxQg" +
                "bMY/UFxNTSQEwX1vBUnMBVQDJrGDeYGBKFnPaKsow5wtCLxgkGd9wG0EeQE9RN4/WQ+FT6H5otgT7ZgpQoMaJx3C5BDXzhLoBCyLue7knCFrX5eeZmH7ebrc" +
                "myf5hjM+NeYCBDvBFLpWGXzFV0x2zmDa20gwiKtBZQ787vIr77djMLC1INQijiSZmACdcqYRHUtfDFaL9+WIe5mj9CNsS/TYetnqXprd5gufw2nx5fWoxkb" +
                "jrj4CAUscv+cij13XPC4XCRIHAjONNn+kr4Ue0H4aOINqHSAyA1AjhkG7aZckUQWyat54hnMT+Qd5Bg0ANsWeGaDWnlfej9v7Gt2G6kBNDxXKWHCPg+lwto" +
                "CH9vzY+9SyK155l6pCVnhlDLI8+dbV2vDyVH9r/0kpftXptEp1Cl/rSYDCzhAzUzeFhX4EMCX3RAROZ469t3mMBq15LzcAQlD6U8dHPU4u3bTk/UfQNgGQv" +
                "yViW8P8s6DRT+zweLiMwBAhO/+MTF0/7nneilGPzM/kc/rAlBij6PWIc+pFcLhdJIKWpJCW4fJ1o4TEQxA0KkAiGUSe/bMcO1kIQOSFhfGlg7nsip0GevN7" +
                "xxLAyOlGah2gZk12pZ7HWcv8FP/2YuT5B34Wrbv3DLy/6vr/o+f4JBMUitqJFPP5djm3PBYkWumFq0Fq1XgXP8yZi4ar+iz8NvRhUwmofEEnBDqy38Ht6hh" +
                "Etp8t6noukYY/zfgtZoaHZCu7CVs/OP/mW4ys9QtKtGWf2fZ9e4twvIzssYYhVLhSKd3XczqF2u13EYx7PQLA1EFASTi+SJSdyhQ3K+NsLapWydbWUHahVUe" +
                "Gpn797+brv1U4ax/61f6CVTGmCQ1mtaEplUW1UxFT4DASR1kt/S1S9oo6Bxmbn6QvPvv2e5R25VxOz0qhc77hsgKOcAJrFYTq4JgQEG8KQ8kfW1aqk+veW9" +
                "fGv/PKrlnf93t8Aj7+BBOCU0QhLhlFQy7CFLYJgQ/lVDYLz5F8NYy8bv7Oy/u77U/fg7FSDICujKVZ2C7KSgSAr8P8CDADTllbPyHwVRAAAAABJRU5ErkJg" +
                "gg==";

            return Convert.FromBase64String(base64img);
        }
    }
}
