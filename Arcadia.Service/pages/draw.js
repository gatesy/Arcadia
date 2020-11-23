const cell_size = 40;
const num_of_cells = 19;
const pebble_cell_pc = 0.75;

let canvas = document.getElementById("board");
let ctx = canvas.getContext("2d");

for(let row = 1; row <= num_of_cells; row++) {
    ctx.moveTo(cell_size, row * cell_size);
    ctx.lineTo(cell_size * num_of_cells, row * cell_size);
    ctx.stroke();
}

for(let col = 1; col <= num_of_cells; col++) {
    ctx.moveTo(col * cell_size, cell_size);
    ctx.lineTo(col * cell_size, cell_size * num_of_cells);
    ctx.stroke();
}

function drawPebble(colour, row, col) {
    let x = col * cell_size + cell_size / 2;
    let y = row * cell_size + cell_size / 2;
    
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

drawPebble("black", 10, 10);
drawPebble("black", 9, 9);
drawPebble("white", 8,9);