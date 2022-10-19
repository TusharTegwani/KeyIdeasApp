using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using NativeMedia;
using Xamarin.Forms.Xaml;
using Foundation;
using Android.App;
using ImageFromXamarinUI;
using Plugin.ImageEdit;
using Contacts;
using Android.Hardware.Camera2.Params;

namespace KeyIdeasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageEditor : ContentPage
    {

        public ImageEditor()
        {

            InitializeComponent();

        }
       
        string PhotoPath;

        FileResult res;
        async void ButtonClicked(Object sender, EventArgs e)
        {
           
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please select a photo from gallery"
            });
            if (result != null)
            {
                res = result;
                await LoadPhotoAsync(result);

                var stream = await result.OpenReadAsync();




                resultImage.Source = ImageSource.FromStream(() => stream);


                //var ss = result;
                //await MediaGallery.SaveAsync(MediaFileType.Image, await ss.OpenReadAsync() , "myImage.png");

            }


        }

        async void Button1Clicked(object sender, EventArgs e)
        {
            
            var result = await MediaPicker.CapturePhotoAsync();
            if (result != null)
            {
                res = result;
                var stream = await result.OpenReadAsync();
                await LoadPhotoAsync(result);
                resultImage.Source = ImageSource.FromStream(() => stream);

            }

        }

        private async void BtnCrop(object sender, EventArgs e)
        {
            System.Console.WriteLine("Crop Pressed");
            hei.Opacity = 1;
            wid.Opacity = 1;
            if (!string.IsNullOrWhiteSpace(hei.Text) && !string.IsNullOrWhiteSpace(wid.Text))
            {
                try
                {
                    double h = Int32.Parse(hei.Text);
                    double w = Int32.Parse(wid.Text);
                    if (h > 0 && w > 0 && h < 401 && w < 401)
                    {
                        rect.WidthRequest = w;
                        rect.HeightRequest = h;
                        if (h > 0 && h < 100) { resultImage.ScaleY = 4.7; }
                        else if (h >= 100 && h < 200) { resultImage.ScaleY = 4.3; }
                        else if (h >= 200 && h < 300) { resultImage.ScaleY = 3.8; }
                        else { resultImage.ScaleY = 3.5; }
                        if (w > 0 && w < 100) { resultImage.ScaleX = 4.7; }
                        else if (w >= 100 && w < 200) { resultImage.ScaleX = 4.3; }
                        else if (w >= 200 && w < 300) { resultImage.ScaleX = 3.8; }
                        else { resultImage.ScaleX = 3.5; }
                        //var ss = await rot_crop.CaptureImageAsync();
                        var ss = await Screenshot.CaptureAsync();
                        await MediaGallery.SaveAsync(MediaFileType.Image, await ss.OpenReadAsync(), "finalResul.png");
                        await DisplayAlert("Success", "Image Cropped Successfully", "OK");
                        resultImage.ScaleX=1;resultImage.ScaleY = 1;
                    }
                    else
                    {
                        await DisplayAlert("Invalid Input", "Please enter values between 0-400", "OK");
                        wid.Text = "";
                        hei.Text = "";
                        wid.Placeholder = "Enter Width";
                        hei.Placeholder = "Enter Height";
                    }

                }
                catch (Exception ex)
                {
                    wid.Text = "";
                    hei.Text = "";
                    wid.Placeholder = "Enter Width";
                    hei.Placeholder = "Enter Height";
                    await DisplayAlert("Error", "Please enter correct values", "OK");
                }
            }

        }
        int count = 0;

        
        private void BtnRot(object sender, EventArgs e)
        {
            
            System.Console.WriteLine("Rotate Pressed");
            resultImage.Rotation =90+count*90;
            count++;
            
        }
        

        async Task LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }
            // save the file into local storage
            var newFile = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);

            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);
            PhotoPath = newFile;
        }

        private async void BtnSave(object sender, EventArgs e)
        {
            System.Console.WriteLine("SavePressed");
            await DisplayAlert("", "Image Saved Successfully", "OK");
            //var ss = await Screenshot.CaptureAsync();
            var ss =await rot_crop.CaptureImageAsync();
            
            await MediaGallery.SaveAsync(MediaFileType.Image, ss, "finalResul.png");
        }

        


    }
}