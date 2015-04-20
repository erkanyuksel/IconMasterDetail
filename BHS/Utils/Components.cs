using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BHS.Utils
{
    public class Components
    {

        public static ViewCell createEntry(string Label, bool password = false, bool enable = true)
        {
            return new ViewCell()
            {
                View = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 0,
                    Children = { 
                        new Entry{
                            Placeholder = Label,
                            IsPassword = password,
                            HorizontalOptions = LayoutOptions.FillAndExpand
}
                    },
                    IsEnabled = enable
                }

            };
        }
        public static ViewCell createButton(string Label)
        {
            return new ViewCell()
            {
                View = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 0,
                    Children = {
                        new Button{
                            Text = Label,
                            HorizontalOptions = LayoutOptions.EndAndExpand
                        }
                    }
                }
            };
        }

        public static ViewCell createImageView(string url)
        {
            return new ViewCell()
            {
                View = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 0,
                    Children = {
                        new Xamarin.Forms.Image{
                            Source = url,
                            WidthRequest = 50,
                            HeightRequest = 50,
                            HorizontalOptions = LayoutOptions.Start
                        }
                    }
                }
            };
        }

        public static ViewCell createList(List<string> source, string Label)
        {
            Picker picker = new Picker
            {
                Title = Label,
                VerticalOptions = LayoutOptions.EndAndExpand
            };

            foreach (var item in source)
            {
                picker.Items.Add(item);
            }

            return new ViewCell()
            {
                View = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 0,
                    Children = {
                       picker
                            

                    }
                }
            };

        }

    }
}
