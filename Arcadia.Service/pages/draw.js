const cell_size = 40;
const num_of_cells = 18;
const pebble_cell_pc = 0.75;

let canvas = document.getElementById("board");
let ctx = canvas.getContext("2d");

function drawBoard() {
    for(let row = 0; row <= num_of_cells; row++) {
        ctx.moveTo(0, row * cell_size);
        ctx.lineTo(cell_size * num_of_cells, row * cell_size);
        ctx.stroke();
    }

    for(let col = 0; col <= num_of_cells; col++) {
        ctx.moveTo(col * cell_size, 0);
        ctx.lineTo(col * cell_size, cell_size * num_of_cells);
        ctx.stroke();
    }
}

function drawPebble(colour, col, row) {
    let x = col * cell_size;
    let y = row * cell_size;
    
    // Draw a filled circle
    ctx.beginPath();
    ctx.arc(x, y, (cell_size / 2) * pebble_cell_pc, 0, 2 * Math.PI);
    ctx.fillStyle = colour;
    ctx.fill();
    
    // Draw a black outline
    ctx.beginPath();
    ctx.lineWidth = 2;
    ctx.arc(x, y, (cell_size / 2) * pebble_cell_pc, 0, 2 * Math.PI);
    ctx.stroke();
}

ctx.translate(cell_size, cell_size);
drawBoard();

// Get the board layout from web app
fetch("/board").then(function(response) {
    response.text().then(function(text) {
        document.getElementById("scratch").innerHTML = text;
        JSON.parse(text).forEach(element => {
            drawPebble(element.pebble.case, element.x, element.y);
        });
    });
});

// Support clicking on the cells
canvas.addEventListener("click", function(event) {
    let x = event.offsetX - cell_size;
    let y = event.offsetY - cell_size;
    let col = Math.floor((event.offsetX - cell_size / 2) / cell_size);
    let row = Math.floor((event.offsetY - cell_size / 2) / cell_size);
    document.getElementById("status").innerHTML = `Coordinates: (${x}, ${y}), Cell: (${col}, ${row})`;
});