const navButton = document.querySelector('.nav-button');
const phoneNav = document.querySelector('.phone-nav');
const closeButton = document.querySelector('.close');
const container = document.querySelector('.container-fluid');


navButton.addEventListener('click', function () {
    phoneNav.classList.remove('hidden');
    container.classList.add('hidden');
})

closeButton.addEventListener('click', function () {
    phoneNav.classList.add('hidden');
    container.classList.remove('hidden');
})