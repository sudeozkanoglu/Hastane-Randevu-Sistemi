// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function AnaBilimleriDoldur(lstHastaneCtrl, lstAnaBilimId) {
    var lstAnaBilimler = $("#" + lstAnaBilimId);
    lstAnaBilimler.empty();

    var selectedHastane = lstHastaneCtrl.options[lstHastaneCtrl.selectedIndex].value;

    if (selectedHastane != null && selectedHastane != '') {
        $.getJSON("/Doktor/GetAnaBilimByHastane", { hastaneId: selectedHastane }, function (anabilimler) {
            if (anabilimler != null && !jQuery.isEmptyObject(anabilimler)) {
                $.each(anabilimler, function (index, anabilim) {
                    lstAnaBilimler.append($('<option/>',
                        {
                            value: anabilim.value,
                            text: anabilim.text
                        }));
                });
            };
        });
    }
    return;
}

function KlinikleriDoldur(lstHastaneCtrl, lstKlinikId) {
    var lstKlinikler = $("#" + lstKlinikId);
    lstKlinikler.empty();

    var selectedHastane = lstHastaneCtrl.options[lstHastaneCtrl.selectedIndex].value;

    if (selectedHastane != null && selectedHastane != '') {
        $.getJSON("/Doktor/GetKlinikByHastane", { hastaneId: selectedHastane }, function (klinikler) {
            if (klinikler != null && !jQuery.isEmptyObject(klinikler)) {
                $.each(klinikler, function (index, klinik) {
                    lstKlinikler.append($('<option/>',
                        {
                            value: klinik.value,
                            text: klinik.text
                        }));
                });
            };
        });
    }
    return;
}

function PoliklinikleriDoldur(lstKlinikCtrl, lstPoliklinikId) {
    var lstPoliklinikler = $("#" + lstPoliklinikId);
    lstPoliklinikler.empty();

    var selectedKlinik = lstKlinikCtrl.options[lstKlinikCtrl.selectedIndex].value;

    if (selectedKlinik != null && selectedKlinik != '') {
        $.getJSON("/Doktor/GetPoliklinikByKlinik", { klinikId: selectedKlinik }, function (poliklinikler) {
            if (poliklinikler != null && !jQuery.isEmptyObject(poliklinikler)) {
                $.each(poliklinikler, function (index, poliklinik) {
                    lstPoliklinikler.append($('<option/>',
                        {
                            value: poliklinik.value,
                            text: poliklinik.text
                        }));
                });
            };
        });
    }
    return;
}
function DoktoruDoldur(lstKlinikCtrl, lstDoktorId) {
    var lstDoktorlar = $("#" + lstDoktorId);
    lstDoktorlar.empty();

    var selectedKlinik = lstKlinikCtrl.options[lstKlinikCtrl.selectedIndex].value;

    if (selectedKlinik != null && selectedKlinik != '') {
        $.getJSON("/Poliklinik/GetDoktorByKlinik", { klinikId: selectedKlinik }, function (doktorlar) {
            if (doktorlar != null && !jQuery.isEmptyObject(doktorlar)) {
                $.each(doktorlar, function (index, doktor) {
                    lstDoktorlar.append($('<option/>',
                        {
                            value: doktor.value,
                            text: doktor.text
                        }));
                });
            };
        });
    }
    return;
}