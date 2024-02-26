// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function scrollToBottom() {
    window.scrollTo({ top: document.body.scrollHeight, behavior: 'smooth' });
}

//kolla URL
var currentUrl = window.location.href;

//kolla om URL stämmer
if (currentUrl.includes("Trollhattan")) {
    //fixa stilar/funktioner beroende på det som ska hända om URL:en stämmer
    var navLink = document.querySelector('a.nav-link.dropdown-toggle');

    navLink.textContent = 'Trollhättan';
    navLink.classList.add('chosen-section-highlight-text');
}

//kolla om URL stämmer
if (currentUrl.includes("Vastervik")) {
    //fixa stilar/funktioner beroende på det som ska hända om URL:en stämmer
    var navLink = document.querySelector('a.nav-link.dropdown-toggle');

    navLink.textContent = 'Västervik';
    navLink.classList.add('chosen-section-highlight-text');
}


if (currentUrl.includes("Trollhattan") & currentUrl.includes("Sports")) {

    var navLink = document.querySelector('#trollhattan-sports');

    navLink.textContent = 'SPORT & FRILUFTSLIV';
    navLink.classList.add('chosen-section-highlight-text');

} 

if (currentUrl.includes("Trollhattan") & currentUrl.includes("Socializing")) {

    var navLink = document.querySelector('#trollhattan-socializing');

    navLink.textContent = 'ÄTA & DRICKA';
    navLink.classList.add('chosen-section-highlight-text');

}

if (currentUrl.includes("Trollhattan") & currentUrl.includes("Culture")) {

    var navLink = document.querySelector('#trollhattan-culture');

    navLink.textContent = 'KULTUR & NÖJE';
    navLink.classList.add('chosen-section-highlight-text');

}

if (currentUrl.includes("Trollhattan") & currentUrl.includes("Search")) {

    var navLink = document.querySelector('body > header > nav > div.nav-item.dropdown > a:nth-child(2)');

    navLink.textContent = 'SÖK EVENT';
    navLink.classList.add('chosen-section-highlight-text');
}


//smooth transistion bland hemsidan, tas förmodligen bort idk
window.addEventListener('load', function () {
    var loadingScreen = document.querySelector('.loading-screen');
    loadingScreen.classList.add('hidden');
});

    //ändra URL:s så att de som tillhär västervik har 'vastervik' i URL för att 
    //javascript ska funka på alla sidor utan att behöva görta en massa onödig kod