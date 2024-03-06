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
    var navLink = document.querySelector('a.nav-link.dropdown-toggle');
    //sätt stad namn som användaren valt
    navLink.textContent = 'Trollhättan';
    //ändra font stil
    navLink.classList.add('chosen-section-highlight-text');
}


if (currentUrl.includes("Vastervik")) {

    var navLink = document.querySelector('a.nav-link.dropdown-toggle');

    navLink.textContent = 'Västervik';
    navLink.classList.add('chosen-section-highlight-text');
}


if (currentUrl.includes("Trollhattan") & currentUrl.includes("Sports")) {

    var navLink = document.querySelector('#trollhattan-sports');

    navLink.classList.add('chosen-section-highlight-text');


} 

if (currentUrl.includes("Trollhattan") & currentUrl.includes("Socializing")) {

    var navLink = document.querySelector('#trollhattan-socializing');

    navLink.classList.add('chosen-section-highlight-text');

}

if (currentUrl.includes("Trollhattan") & currentUrl.includes("Culture")) {

    var navLink = document.querySelector('#trollhattan-culture');

    navLink.classList.add('chosen-section-highlight-text');

}

if (currentUrl.includes("Trollhattan") & currentUrl.includes("Search")) {

    var navLink = document.querySelector('body > header > nav > div.nav-item.dropdown > a:nth-child(2)');

    navLink.classList.add('chosen-section-highlight-text');
}


    //funktioner för blur effekt på den andra bilden när man hoverar över för
//blir knasigt i css när man försöker ändra en annan saks properties
    //fortsätter på det senare sätter bara upp startsidan först så att den finns

const vvikImage = document.getElementById("startpage-image-vvik");
const thnImage = document.getElementById("startpage-image-thn");