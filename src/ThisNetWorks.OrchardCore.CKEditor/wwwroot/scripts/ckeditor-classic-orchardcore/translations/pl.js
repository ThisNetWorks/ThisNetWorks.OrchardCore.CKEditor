(function(d){	const l = d['pl'] = d['pl'] || {};	l.dictionary=Object.assign(		l.dictionary||{},		{"%0 of %1":"%0 z %1","Block quote":"Cytat blokowy",Bold:"Pogrubienie","Bulleted List":"Lista wypunktowana",Cancel:"Anuluj","Cannot upload file:":"Nie można przesłać pliku:","Choose heading":"Wybierz nagłówek",Column:"Kolumna","Could not insert image at the current position.":"Nie można wstawić obrazka w bieżącej lokalizacji.","Could not obtain resized image URL.":"Nie można pobrać adresu URL obrazka po przeskalowaniu.","Decrease indent":"Zmniejsz wcięcie","Delete column":"Usuń kolumnę","Delete row":"Usuń wiersz",Downloadable:"Do pobrania","Dropdown toolbar":"Rozwijany pasek narzędzi","Edit link":"Edytuj odnośnik","Editor toolbar":"Pasek narzędzi edytora","Header column":"Kolumna nagłówka","Header row":"Wiersz nagłówka",Heading:"Nagłówek","Heading 1":"Nagłówek 1","Heading 2":"Nagłówek 2","Heading 3":"Nagłówek 3","Heading 4":"Nagłówek 4","Heading 5":"Nagłówek 5","Heading 6":"Nagłówek 6","image widget":"Obraz","Increase indent":"Zwiększ wcięcie","Insert column left":"Wstaw kolumnę z lewej","Insert column right":"Wstaw kolumnę z prawej","Insert image or file":"Wstaw obrazek lub plik","Insert paragraph after block":"","Insert paragraph before block":"","Insert row above":"Wstaw wiersz ponad","Insert row below":"Wstaw wiersz poniżej","Insert table":"Wstaw tabelę","Inserting image failed":"Wstawienie obrazka nie powiodło się.",Italic:"Kursywa",Link:"Wstaw odnośnik","Link URL":"Adres URL","Merge cell down":"Scal komórkę w dół","Merge cell left":"Scal komórkę w lewo","Merge cell right":"Scal komórkę w prawo","Merge cell up":"Scal komórkę w górę","Merge cells":"Scal komórki",Next:"Następny","Numbered List":"Lista numerowana","Open in a new tab":"Otwórz w nowej zakładce","Open link in new tab":"Otwórz odnośnik w nowym oknie",Paragraph:"Akapit",Previous:"Poprzedni",Redo:"Ponów","Rich Text Editor":"Edytor tekstu sformatowanego","Rich Text Editor, %0":"Edytor tekstu sformatowanego, %0",Row:"Wiersz",Save:"Zapisz","Select all":"Zaznacz wszystko","Select column":"","Select row":"","Selecting resized image failed":"Wybranie obrazka po przeskalowaniu nie powiodło się.","Show more items":"Pokaż więcej","Split cell horizontally":"Podziel komórkę poziomo","Split cell vertically":"Podziel komórkę pionowo","Table toolbar":"Pasek narzędzi tabel","This link has no URL":"Nie podano adresu URL odnośnika",Undo:"Cofnij",Unlink:"Usuń odnośnik","Upload in progress":"Trwa przesyłanie","Widget toolbar":"Pasek widgetów"}	);l.getPluralForm=function(n){return (n==1 ? 0 : (n%10>=2 && n%10<=4) && (n%100<12 || n%100>14) ? 1 : n!=1 && (n%10>=0 && n%10<=1) || (n%10>=5 && n%10<=9) || (n%100>=12 && n%100<=14) ? 2 : 3);;};})(window.CKEDITOR_TRANSLATIONS||(window.CKEDITOR_TRANSLATIONS={}));