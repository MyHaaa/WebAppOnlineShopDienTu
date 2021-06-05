function ChangeImage(UploadImage, previewImg) {
    if (UploadImage.files && previewImg.files) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImg).attr('src', e.target.result);
        }
        reader.readAsDataURL(UploadImage.files[0]);
    }
}