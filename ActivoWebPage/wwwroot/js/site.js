// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//hero header pil ner script temp funktionalitet
function scrollToBottom() {
    window.scrollTo({ top: document.body.scrollHeight, behavior: 'smooth' });
}

//kolla URL
var currentUrl = window.location.href;

//kolla om URL stämmer
if (currentUrl.includes("Trollhattan")) {
    //fixa stilar/funktioner beroende på det som ska hända om URL:en stämmer
    var navLink = document.querySelector("body > header > nav > div.nav-list > div.nav-item.dropdown > a")
    //sätt stad namn som användaren valt
    navLink.textContent = 'Trollhättan';
    //ändra font stil
    navLink.classList.add('chosen-section-highlight-text');
}


if (currentUrl.includes("Vastervik")) {

    var navLink = document.querySelector("body > header > nav > div.nav-list > div.nav-item.dropdown > a");

    navLink.textContent = 'Västervik';
    navLink.classList.add('chosen-section-highlight-text');
}


if (currentUrl.includes("Sports")) {

    var navLink = document.querySelector('#sports')
    var navLinkDropdown = document.querySelector('#sports-mobile');
    var navLinkSM = document.querySelector("body > header > nav > div.nav-start > div > div.nav-item.content-align-mobile > a");

    navLink.classList.add('chosen-section-highlight-text');
    navLinkSM.textContent = 'SPORT & FRILUFTSLIV';
    navLinkSM.classList.add('chosen-section-highlight-text');
    navLinkDropdown.classList.add('chosen-section-highlight-text');

} 

if (currentUrl.includes("Socializing")) {

    var navLink = document.querySelector('#socializing')
    var navLinkDropdown = document.querySelector('#socializing-mobile');
    var navLinkSM = document.querySelector("body > header > nav > div.nav-start > div > div.nav-item.content-align-mobile > a");

    navLink.classList.add('chosen-section-highlight-text');
    navLinkSM.textContent = 'ÄTA & DRICKA';
    navLinkSM.classList.add('chosen-section-highlight-text');
    navLinkDropdown.classList.add('chosen-section-highlight-text');

} 

if (currentUrl.includes("Culture")) {

    var navLink = document.querySelector('#culture')
    var navLinkDropdown = document.querySelector('#culture-mobile');
    var navLinkSM = document.querySelector("body > header > nav > div.nav-start > div > div.nav-item.content-align-mobile > a");

    navLink.classList.add('chosen-section-highlight-text');
    navLinkSM.textContent = 'KULTUR & NÖJE';
    navLinkSM.classList.add('chosen-section-highlight-text');
    navLinkDropdown.classList.add('chosen-section-highlight-text');

} 

if (currentUrl.includes("Search")) {

    var navLink = document.querySelector("body > header > nav > div > a:nth-child(2)");
    navLink.classList.add('chosen-section-highlight-text');
}


    //funktioner för blur effekt på den andra bilden när man hoverar över för
//blir knasigt i css när man försöker ändra en annan saks properties
    //fortsätter på det senare sätter bara upp startsidan först så att den finns

//karusellknappar
goLeft = document.getElementById("goLeft");
goRight = document.getElementById("goRight");
carousel = document.getElementById("activitesCarousel");

goLeft.addEventListener("click", function () {
    carousel.scrollLeft += -300;
});
goRight.addEventListener("click", function () {
    carousel.scrollLeft += 300;
});

