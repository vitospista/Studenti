# Obiettivo:
Creare una classe che di base funzioni come uno Stack.

Uno Stack è una "pila" di oggetti, su cui posso fare 2 operazioni:

-) mettere in cima alla lista un nuovo elemento;

-) rimuovere l'oggetto che c'è già in cima.

Ma NON posso aggiungere un elemento in mezzo alla pila,
né posso togliere un elemento in mezzo alla pila.

Lo Stack migliorato che si deve implementare deve essere anche osservabile,
nel senso che quando un elemento viene aggiunto o tolto dalla cima,
una notifica deve essere inviata a tutti gli attori in ascolto.

Infine, lo Stack finale deve anche essere interrogabile,
cioè deve dire quanti elementi possiede che rispettano una certa collezione.


# Realizzare:
## 1. Una classe `Stack<T>`, con i metodi:
- costruttore che prende in input il numero massimo di elementi che può tenere.
- `Put` - per mettere un elemento `T` in cima alla pila;
- `Pop` - per togliere un elemento dalla pila e restituirlo al chiamante;
- `CanPop` - per chiedere allo stack se ci sono ancora elementi da tirar fuori
- `CanPut`- per chiedere allo stack se è possibile aggiungere ancora elementi.

Note: se si chiama `Pop` su uno `Stack` vuoto, o il `Put` su uno `Stack` che ha già raggiunto capacità piena, va lanciata una opportuna eccezione.

## 2. Una classe `ObservableStack<T>`
con le stesse funzionalità dello `Stack` precedente,
ma che in più deve notificare quando viene fatto il `Put` o il `Pop` di un elemento.
Suggerimento: implementare questo `ObservableStack` come "publisher" di elementi,
che notifica ad un elenco di subscriber il `Put` o il `Pop` di un elemento.
Questi subscriber dovranno implementare un'interfaccia con due metodi,
uno per gestire la notifica di `Pop` e uno per gestire la notifica di `Push`.
L'`ObservableStack` ovviamente avrà anche dei metodi per iscrivere o disiscrivere un subscriber.

## 3. Una classe `CountableStack<T>`
che oltre alle funzionalità dell'`ObservableStack`, ha un metodo `Count`
che accetta come parametro una condizione di tipo `Func<T, bool>`,
e restituisce il numero di elementi che passano la condizione.

## 4. Un metodo Main
Nel Main, creare un `CountableStack` sugli `int`, fare un po' di `Put` e `Pop`,
verificare che i subscriber ricevono le notifiche, e infine passare delle funzioni
per ricavare quanti elementi dello stack:
- sono pari
- sono maggiori di 10
- sono numeri primi.

NON usare: LINQ, eventi, finestre grafiche, la classe Stack<T> di .NET.
Implementare la soluzione su un progetto Console.