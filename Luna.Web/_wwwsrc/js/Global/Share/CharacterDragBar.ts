var container = document.getElementById('character-container');
var left = document.getElementById('characters');
var right = document.getElementById('details');
var bar = document.getElementById('dragbar');

const drag = (e) => {
    window.getSelection().removeAllRanges();

    let leftX = e.pageX - bar.offsetWidth / 2;
    left.style.width = leftX + 'px';

    let rightX = container.clientWidth - leftX;
    right.style.width = rightX + 'px';

    let value = JSON.stringify({ charactersWidth: leftX, detailsWidth: rightX });

    document.cookie = `dragbar=${value}; secure; samesite=strict; expires=${365*24*60*1000}`;
}

if (bar) {
    bar.addEventListener('mousedown', () => {
        document.addEventListener('mousemove', drag);
    });
}

document.addEventListener('mouseup', () => {
    document.removeEventListener('mousemove', drag);
});