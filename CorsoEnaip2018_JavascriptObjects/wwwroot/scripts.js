// si usa window onload
// quando lo script è inserito nello <head>
//window.onload = function () {
//    var el = document.getElementsByTagName('h1');
//    el[0].style.textAlign = "center";
//}

var emptyArray = [];
var fullArray = ['pear', 'apple', 'banana'];
//for (let i = 0; i < fullArray.length; i++) {
//    console.log(fullArray[i]);
//}
//console.log(fullArray);

// aggiungere un elemento in coda all'array
fullArray.push('kiwi');
//console.log(fullArray);

// js è dinamico, quindi anche in un array
// posso mettere elementi di tipo diverso
var dynArray = [null, 'ciao', 123, fullArray];
//console.log(dynArray);

fullArray.push(['kiwi']);
//console.log(fullArray);

var matrix = [];

for (let i = 0; i < 3; i++) {
    matrix.push([]);
    for (var j = 0; j < 3; j++) {
        matrix[i].push(j + (i*3));
    }
}
//console.log(matrix);


// gli array sono "sparsi":
fullArray[123] = 'elemento fuori range';
//console.log(fullArray);

// non c'è un metodo 'remove' sugli array:
//fullArray.remove('apple'); <-- errore!
var index = fullArray.indexOf('apple');
fullArray.splice(index, 1);
//console.log(fullArray);

var nestedArrayIndex = fullArray.indexOf(['kiwi']);
// nestedArrayIndex = -1, perché l'oggetto che passo
// è un'altra reference rispetto all'array ['kiwi'] che avevo inserito
for (var i = 0; i < fullArray.length; i++) {
    var current = fullArray[i];
    if (current && current instanceof Array &&
        current.length == 1 && current[0] == 'kiwi') {
        break;
    }
}
//console.log("i = " + i);
fullArray.splice(i, 1);
//console.log(fullArray);

// indexOf funziona solo se 
// passo proprio la reference dell'oggetto,
// non un clone dell'oggetto!
var anotherNestedArray = ['nested1', 'nested2'];
fullArray.push(anotherNestedArray);
var anotherNestedIndex = fullArray.indexOf(anotherNestedArray);
//console.log(anotherNestedIndex);

// inizializzo un oggetto con l'elenco di:
// <proprietà>: <valore>,
// le proprietà possono essere valori semplici, funzioni, altri oggetti
var person = {
    name: 'Adam',
    surname: 'Kadmon',
    age: 40,
    specialties: 'trash tv shows on misteries',
    nameComplete: function () {
        return this.name + " " + this.surname;
    },
    address: {
        street: 'via dei Misteri',
        number: 5,
        city: 'Lugano'
    }
};
//console.log(person);
//console.log(person.nameComplete());

// js è un linguaggio dinamico:
// posso aggiungere proprietà ad un oggetto
// anche successivamente
person.fiscalCode = 'qwerhdbvksjfw';
//console.log(person);

// rimuovere proprietà da un oggetto:
// (rarissimo)
delete person.fiscalCode;

// oggi oggetto è considerabile come un dizionario
// posso iterare le proprietà di un oggetto con 'for - in'
for (let prop in person) {
    var row = prop + ": " + person[prop];
    //console.log(row);
}

// per iterare su un array (similmente a come farei col foreach di C#)
// devo usare 'for - of', NON 'for - in'
for (let el of fullArray) {
    //console.log(el);
}

function logThisGlobal() {
    console.log(this);
}
logThisGlobal();

person.logThisOnObject = logThisGlobal;
person.logThisOnObject();
