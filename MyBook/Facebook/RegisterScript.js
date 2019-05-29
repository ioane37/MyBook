window.onload = function () {
    const imageInput = document.querySelector(".image--input");
    const imageContainer = document.querySelector(".image");

    imageInput.addEventListener("change", function () {
        imageContainer.style.backgroundImage = "url('" + imageInput.value + "')";
        imageContainer.style.backgroundSize = "cover";
        imageContainer.style.backgroundRepeat = "noRepeat";

        imageContainer.textContent = "";
    });
}

function AddImage() {

}