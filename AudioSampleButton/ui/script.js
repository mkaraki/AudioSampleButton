function createSamplerCells(width, height, items) {
    var t = document.getElementById("sampler-table");

    for (var r = 0; r < items.length; r++) {
        var tr = document.createElement('tr');
        for (var c = 0; c < items[r].length; c++) {
            var td = document.createElement('td');
            var btn = document.createElement('button');

            if (items[r][c] != null) {
                btn.setAttribute('onclick', `csCall.play('${items[r][c][0]}');`);
            }
            btn.innerText = items[r][c] == null ? 'N/A' : items[r][c][1]
            var colorstr = items[r][c] == null ? 'lightgray' : items[r][c][2];
            var bcolorstr = items[r][c] == null ? 'darkgray' : items[r][c][3];

            btn.setAttribute('style', `width: ${width}px; height: ${height}px; color: ${colorstr}; background-color: ${bcolorstr};`);

            td.appendChild(btn);
            tr.appendChild(td)
        }
        t.appendChild(tr);
    }
}

function displayBanks(items) {
    var b = document.getElementById('banklist');

    for (var i = 0; i < items.length; i++) {
        var btn = document.createElement('button');
        btn.innerText = items[i];
        btn.setAttribute('onclick', `csCall.loadBank('${items[i]}');`);
        b.appendChild(btn);
    }
}