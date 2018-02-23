// si usa window onload
// quando lo script è inserito nello <head>
//window.onload = function () {
//    var el = document.getElementsByTagName('h1');
//    el[0].style.textAlign = "center";
//}

var emptyArray = [];
var fullArray = ['pear', 'apple', 'banana'];
for (let i = 0; i < fullArray.length; i++) {
    // accedo agli elementi di un array con l'indexer []
    console.log(fullArray[i]);
}
//il log di un array mi fa vedere tutti gli elementi dell'array.
console.log(fullArray);

// aggiungere un elemento in coda all'array
fullArray.push('kiwi');

// js è dinamico, quindi anche in un array
// posso mettere elementi di tipo diverso
var dynArray = [null, 'ciao', 123, fullArray];

// in questo caso aggiungo all'array come elemento
// un array annidato
fullArray.push(['kiwi']);

// posso creare una matrice come array di array:
var matrix = [];
for (let i = 0; i < 3; i++) {
    matrix.push([]);
    for (var j = 0; j < 3; j++) {
        matrix[i].push(j + (i*3));
    }
}

// gli array sono "sparsi".
// posso inserire un elemento all'indice che voglio:
fullArray[123] = 'elemento fuori range';

// non c'è un metodo 'remove' sugli array.
// devo ricavare l'indice dell'elemento da rimuovere e poi usare 'Splice':
var index = fullArray.indexOf('apple');
fullArray.splice(index, 1);

var nestedArrayIndex = fullArray.indexOf(['kiwi']);
// nestedArrayIndex = -1, cioè non ha trovato l'oggetto.
// Questo perché l'oggetto che passo è un nuovo array,
// memorizzato su un'altra area dello heap rispetto all'array che avevo inserito.
// Per ricavare l'indice devo usare un sistema più macchinoso:
for (var i = 0; i < fullArray.length; i++) {
    var current = fullArray[i];
    if (current && current instanceof Array &&
        current.length == 1 && current[0] == 'kiwi') {
        break;
    }
}
// anche fuori dal 'for' vedo la variabile i,
// perché in js non esiste lo scope per blocco di codice, solo gli scope globale e di funzione.
//console.log("i = " + i);
fullArray.splice(i, 1);

// indexOf funziona se passo proprio la reference dell'oggetto cercato:
var anotherNestedArray = ['nested1', 'nested2'];
fullArray.push(anotherNestedArray);
var anotherNestedIndex = fullArray.indexOf(anotherNestedArray);
// qui anotherNestedIndex è != da -1.

// ------ OGGETTI IN JAVASCRIPT ------
// inizializzo un oggetto con l'elenco di:
// <proprietà>: <valore>,
// le proprietà possono essere valori semplici, funzioni, altri oggetti annidati
var person1 = {
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
person1.fiscalCode = 'qwerhdbvksjfw';

// posso rimuovere proprietà da un oggetto (rarissimo da trovare):
delete person1.fiscalCode;

// oggi oggetto è considerabile come un dizionario,
// posso iterare le proprietà di un oggetto con 'for - in'
for (var prop in person1) {
    var row = prop + ": " + person1[prop];
    //console.log(row);
}

// per iterare su un array (similmente a come farei col foreach di C#)
// devo usare 'for - of', NON 'for - in'!
for (var el of fullArray) {
    //console.log(el);
}
// altrimenti js itera sulle proprietà dell'array come farebbe per qualsiasi altro oggetto,
// invece di iterare sugli elementi che l'array contiene.


// ------ THIS ------
// Il 'this' in js è dinamico, cioè dipende dal contesto in cui è chiamato.

function logThisGlobal() {
    console.log(this);
}
// qui il contesto è quello globale, quindi il 'this' si riferisce alla Window.
console.log("logThisGlobal");
logThisGlobal();

// qui invece uso la funzione come proprietà di un oggetto,
// quindi il 'this' è l'oggetto stesso.
person1.logThisOnObject = logThisGlobal;
console.log("logThisOnObject");
person1.logThisOnObject();

// posso indicare ad una funzione quale 'this' usare con il metodo 'call':
console.log("logThisGlobal called with person");
logThisGlobal.call(person1);

// la funzione ha dei metodi? Sì, perché in js anche le funzioni
// sono degli oggetti a tutti gli effetti, e quindi hanno metodi, proprietà...

var person2 = {
    name: "Bob",
    surname: "Marley",
};
person2.logThisOnObject = person1.logThisOnObject;
console.log("person2.logThisOnObject");
person2.logThisOnObject();
person2.logThisOnObject.call(person1);

// uso questo container dai click dei pulsanti 2 e 3 presenti sull'HTML.
var container = {
    // qui creo una funzione che al suo interno chiama 'logThisGlobal'.
    // in questo caso il 'this' resta legato alla Window
    logContainingLogThisGlobal: function () {
        logThisGlobal();
    },
    // qui assegno ad una proprietà del container proprio la funzione logThisGlobal,
    // quindi il 'this' viene reindirizzato sull'oggetto 'container'.
    logWithLogThisGlobal: logThisGlobal,
};

// associo al 'click' del pulsante una funzione
// che al suo interno chiama il 'logThisGlobal'.
// qui il 'this' resta legato alla Window.
var b4 = document.getElementById('b4');
b4.addEventListener('click', function() {
    logThisGlobal();
});

// qui invece uso come handler del click proprio la funzione 'logThisGlobal',
// quindi il this è il pulsante stesso.
var b5 = document.getElementById('b5');
b5.addEventListener('click', logThisGlobal);

// ------ COSTRUTTORI ------
function Rectangle(w, h) {
    this.width = w;
    this.height = h;
    this.area = function () {
        return w * h;
    }
    return this;
}
// posso usare una funzione come COSTRUTTORE, aggiungendo l'operatore 'new':
var r = new Rectangle(2, 5);

// quando uso il new, succedono queste cose:
// - viene creato un oggetto vuoto;
// - il 'this' presente nella funzione viene associato a questo oggetto;
// - sull'oggetto viene settata la proprietà '__proto__'
//     col valore del prototype della funzione (vedi Rectangle più avanti);
// - viene settata sull'oggetto la proprietà 'constructor' che è la funzione stessa;
// - viene restituito l'oggetto così creato (anche senza istruzione 'return').

console.log("new Rectangle created:");
console.log(r);
console.log(r.constructor);
// l'oggetto craeto è come tutti gli altri oggetti js:
// posso aggiungere proprietà, chiamare metodi, ecc.
r.length = 12;
console.log("l'area di r è: " + r.area());
var r2 = new Rectangle(1, 3);

// se non uso il new, la funzione opera "normalmente":
// il 'this' dipende dal contesto che chiama la funzione.
console.log("Rectangle function without new:");
// qui è chiamata in contesto globale, quindi il suo 'this' è la Window.
console.log(Rectangle(6, 7));

// ogni funzione ha una proprietà 'prototype', che è un oggetto,
// su cui posso aggiungere proprietà:
Rectangle.prototype.area = function () {
    return this.height * this.width;
}
// L'oggetto creato con il 'new' ha la proprietà '__proto__'
// che punta proprio a quel 'prototype'.
// Col il __proto__, creo una 'catena di delegazione'.
// Quando chiamo su 'r' una proprietà che 'r' non ha,
// js la cerca nel suo '__proto__', e poi nel '__proto__' del '__proto__',
// e così avanti finché non la trova.
// Se arriva in fondo alla catena e non la trova:
// - restituisce 'undefined' se è una proprietà di 'valore' (come la 'height' del rettangolo);
// - lancia un'eccezione se la proprità è una funzione
//     (non è mai possible chiamare una funzione che risulta 'undefined').
// js NON ha classi.
// infatti è l'unico linguaggio autenticamente "object-oriented".
// C#, Java, ecc sono più linguaggi "class-oriented".

// js NON ha ereditarietà.
// js ha la "prototype delegation".
// Siccome "assomiglia" all'ereditarietà dei linguaggi statici come C# e Java,
// spesso si sente parlare di "prototypal inheritance",
// ma è una dicitura errata.
// I meccanismi dell'ereditarietà sono molto diversi
// da quelli della delegazione di js.
// Una delle differenze fondamentali è che la catena di ereditarietà
// è stabilita a compile-time una volta per tutte, e non può essere cambiata.
// Invece i prototype degli oggetti di js
// possono essere cambiati a runtime quando si vuole.

// posso usare il 'this' nel costruttore in combinazione col 'prototype'
// per creare le proprietà sull'oggetto.
function Circle() {
    this.color = "red";
}
Circle.prototype.radius = 10;
Circle.prototype.area = function () {
    return Circle.prototype.radius * Circle.prototype.radius * Math.PI;
}
var c = new Circle();
console.log("c.radius: " + c.radius);
console.log("c.area: " + c.area());

// C'è una differenza: le proprietà create con il 'this'
// sono proprietà dell'oggetto stesso, quelle del prototipo no.
console.log("which properties of the Circle c are 'own' properties?");
for (var prop in c) {
    console.log(prop + ": " + c.hasOwnProperty(prop));
}

// dall'oggetto accedo al prototipo con "__proto__"
console.log("stampa prototipo:");
console.log(c.__proto__);
// dalla funzione costruttore accedo al prototipo con "prototype"
console.log(Circle.prototype);
// ma sono lo stesso oggetto.

// posso seguire la catena di prototipi:
console.log("prototype of prototype");
console.log(c.__proto__.__proto__);

// l'oggetto finale della catena è sempre un object di base,
// il cui costruttore è la funzione Object() di js.

// ------ ESEMPIO DI DELEGATION ------
// il codice seguente mostra come creare una catena di delegazione,
// con un oggetto base LivingBeing,
// da cui "derivano" Vegetable e Animal (da cui poi deriva Human).
function LivingBeing() { }
LivingBeing.prototype.live = function () {
    console.log("I'm alive!");
};
LivingBeing.prototype.breath = function () {
    console.log("I'm breathing!");
}
var l = new LivingBeing();

function Animal() { }
Animal.prototype.eat = function () {
    console.log("I'm eating!");
};
Animal.prototype.breath = function () {
    console.log("I'm getting oxygen inside my lungs!");
}
var a = new Animal();

function Human() { }
Human.prototype.speak = function () {
    console.log("I'm speaking!");
}

// uso questo sistema per concatenare i prototipi:
Animal.prototype.__proto__ = LivingBeing.prototype;
Human.prototype.__proto__ = Animal.prototype;

var h = new Human();
console.log("human:");
h.live();
h.eat();
h.speak();
console.log(h.__proto__.__proto__.__proto__.__proto__);

function Vegetable() { }
Vegetable.prototype.__proto__ = LivingBeing.prototype;
Vegetable.prototype.getSun = function () {
    console.log("I'm getting the sun light!");
}
Vegetable.prototype.breath = function () {
    console.log("I'm getting CO2 from the air!");
}
var v = new Vegetable();
v.getSun();

// Ora chiamerò il metodo 'breath' su tutti gli oggetti creati.
console.log("all the breathing:");

// su 'l' non c'è un metodo 'breath'.
// quindi viene cercato sul suo __proto__ (cioè LivingBeing.prototype).
// Lì c'è, e viene eseguito.
l.breath();

// su 'a' non c'è 'breath'.
// viene cercato su 'a.__proto__' (cioè 'Animal.prototype'), ma non c'è.
// allora viene cercato su 'a.__proto__.__proto__', che è 'LivingBeing.prototype'.
a.breath();

// su 'h' non c'è 'breath'.
// viene cercato su 'h.__proto__' (cioè 'Human.prototype'), ma non c'è.
// allora viene cercato su 'h.__proto__.__proto__', che è 'Animal.prototype', ma non c'è.
// allora viene cercato su 'a.__proto__.__proto__.__proto__', che è 'LivingBeing.prototype'.
h.breath();

// su 'v' non c'è 'breath'.
// viene cercato su 'v.__proto__' (cioè 'Vegetable.prototype'), ma non c'è.
// allora viene cercato su 'v.__proto__.__proto__', che è 'LivingBeing.prototype'.
v.breath();

// non c'è NESSUN override.
// semplicemente viene usato il primo match trovato nella catena di delegazione.

var asmaticPerson = new Human();
asmaticPerson.breath = function () {
    console.log("I'm breathing with difficulty");
}
// in questo caso, ho settato una funzione 'breath' direttamente sull'oggetto.
// Siccome sull'oggetto 'asmaticPerson' c'è già la funzione,
// non ho bisogno di risalire la catena di delegazione.
asmaticPerson.breath();

// ma 'asmaticPerson.__proto__.__proto__.__proto__' continua ad avere
// il suo metodo 'breath'.
// Semplicemente questo metodo non viene mai raggiunto perché
// c'è già un metodo 'breath' sul primo oggetto della catena
// (cioè l'oggetto stesso su cui si chiama la funzione), e viene usato quello.

// in js non esistono le interfacce.
// non esistendo 'classi', non esiste neanche il concetto di 'classe astratta'
// e nemmeno quello di 'virtual' o di 'override'.