let line = gets().split(" ");
let H = parseInt(line[0]);
let P = parseInt(line[1]);

let media = H * P;
let mediaFinal = media/12;

print(" " + mediaFinal.toFixed(3));