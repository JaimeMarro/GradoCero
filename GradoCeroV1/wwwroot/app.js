function insertarEnCursor(id, texto) {
    const el = document.getElementById(id);
    if (!el) return;
    const inicio = el.selectionStart;
    const fin = el.selectionEnd;
    el.value = el.value.substring(0, inicio) + texto + el.value.substring(fin);
    el.selectionStart = el.selectionEnd = inicio + texto.length;
    el.dispatchEvent(new Event('input'));
}