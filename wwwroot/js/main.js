// Menyvariabler
const menuIcon = document.querySelector('.menuicon');
const navLinks = document.querySelector('.navlinks');
const body = document.querySelector('body');

// Öppna meny
menuIcon.addEventListener('click', function() {
    navLinks.classList.toggle('open');
    
    // Ser till att man inte kan skrolla med menyn öppen
    if (body.style.position != 'fixed') {
        body.style.position = 'fixed';
    }
    
    else if (body.style.position == 'fixed') {
        body.style.position = 'static';
    }
});