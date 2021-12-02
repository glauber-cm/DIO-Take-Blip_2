var n = parseInt(gets());

function CalcDias(qtdeComida){
  if(qtdeComida <= 1.0){
    return 0;
  }
  
  const comeComida = qtdeComida / 2.0;
  
  return 1 + CalcDias(comeComida);
}

while(n --> 0){
  const quantidadeComida = parseFloat(gets());
  const dias = CalcDias(quantidadeComida);
  
  console.log(dias, 'dias');
}