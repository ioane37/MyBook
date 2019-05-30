function AddImage() {
    const imageInput = document.querySelector(".image--input");
    const imageContainer = document.querySelector(".image");
    const imageHolder = document.querySelector(".imageHolder");
    const image = document.querySelector(".image--container");

    image.classList.remove("image--disabled");
    image.classList.add("image--enabled");

    imageInput.addEventListener("input", function () {
        imageHolder.src = imageInput.value;
        imageHolder.backgroundSize = "cover";

        if (imageContainer.childElementCount > 1) {
            imageContainer.removeChild(imageContainer.firstElementChild);
        }
    });
}