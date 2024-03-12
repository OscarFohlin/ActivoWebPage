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


document.addEventListener("DOMContentLoaded", function () {

    //const isUserLoggedIn = (getCookie('loggedIn') === 'true'){};
    
    //hård kodat sålänge, blir som något ovan vid ett senare tillfälle
    const isUserLoggedIn = true;

    //íd:t av de element som ändras, beroende på inloggningstatus
    const loggedInMenuElement = document.querySelector("#logged-in-menu");
    const loggedOutMenuElement = document.querySelector("#logged-out-menu");
    setTimeout(function () {

        //så basically tänker att den ska vänta med att sätta ut vad som ska stå
        //tills scriptet avgört om användaren är inloggad eller inte, får se om det ändras

        if (isUserLoggedIn) {
            loggedInMenuElement.style.display = 'block';
        } else {
            loggedOutMenuElement.style.display = 'block';
        }
    }, 100); //sätter en delay för att göra flickering lite bättre
    const headerContentReady = determineHeaderContent();
});


function determineHeaderContent() {
    const placeholderElement = document.querySelector("#skeleton-profile-placeholder");
    placeholderElement.style.display = 'none';
}