﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let createForm = document.querySelector('#createajax');


function removeForm() {
    /*$('#createajax').html = "";*/
    createForm.innerHTML = "";
}

function fail() {
    console.log('Model error: check your input');
}