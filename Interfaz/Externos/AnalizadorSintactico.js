const gramaticasIf = {
  S: [
    "PRHACER LLAVEABRIR",
    "PRASIG PRV ASIGNACION CE;",
    "PRASIG PRV IDEN CE;",
    "ASIGNACION CE;",
    "PRSI COND",
    "PRWHILE COND",
    "INICIO",
    "FIN",
    "LLAVEABRIR",
    "LLAVECIERRE",
    "IN_ASIGNACION",
  ],

  IN_ASIGNACION: [
    //DECLARAR VARIABLE v1;
    "PRI6 PRV1 IDEN CE13",
    //DECLARAR Y ASIGNAR
    "PRI6 PRV1 ASIG CADENA CE13",
    "PRI6 PRV1 ASIG OPA CE13",
    //ASIGNAR
    "IDEN ASIG EX CE13",
  ],

  LLAVECIERRE: [
    "CE} CE;"
  ],

  LLAVEABRIR: [
    "CE{"
  ],

  COND: [
    "OPLO",
    "OPRE",
    "OPRE LLAVEABRIR",
    "OPLO LLAVEABRIR",
    "OPRE LLAVECIERRE",
    "OPLO LLAVECIERRE",
    "BOOLEANO"
  ],

  EX: [
    "CONN",
    "IDEN",
    "CAD",
    "EX OPRA IDEN",
    "IDEN OPRA EX",
    "IDEN OPRA CONN",
    "CONN OPRA IDEN",
    "EX OPRA EX",
    "CES( EX CES)",
    "CES( OPA CES)",
    "CES( IDEN CES)",
    "OPA",
    "OPLO",
    "OPRE",
    "COND",
  ],
  OPA: [
    "CONN OPRA CONN",
    "IDEN OPRA IDEN",
    "EX OPRA EX",
    "EX OPRA CONN",
    "CONN OPRA EX",
    "OPA OPRA IDEN",
    "IDEN OPRA OPA",
  ],
  OPRA: ["+", "-", "*", "/"],
  OPRE: [
    "EX oprel EX",
    "EX oprel OPAR",
    "CONN oprel CONN",
    "OPAR oprel EX",
    "CONN oprel IDEN",
    "IDEN oprel CONN",
    "IDEN oprel IDEN",
    "CES( OPRE CES)",
    "CES( OPAR CES)",
  ],
  OPLO: [
    "CES( oplog CES)",
    "CES( oplog CES)",
    "OPLO oplog OPRE",
    "OPRE oplog OPLO",
    "OPRE oprel OPRE",
    "OPRE oplog OPRE",
    "OPLO oplog OPLO",
    "EX oplog EX",
    "EX oplog CONN",
    "CONN oplog EX",
    "CES( OPLO CES)",
    "CES( BOOLEANO CES)",
  ],
  BOOLEANO: ["TRUE", "FALSE"],
};

const reduceCadena = (origen, puntero, fin, nuevo) => {
  const origenTokens = origen.split(" ");
  const len = origenTokens.length;
  const arrayRetorno = origenTokens.slice(0, puntero).concat([`${nuevo}`]);
  const restante = origenTokens.slice(fin, len);

  return arrayRetorno.concat(restante).join(" ");
};

function recorridoCadenaTokens(tokensInput) {
  let tokensInputToArray = tokensInput.split(" ");
  let longitudTokens = tokensInputToArray.length;

  console.log("-->  ", tokensInput);

  for (var ii = longitudTokens - 1; ii >= 0; ii--) {
    for (const [k, v] of Object.entries(gramaticasIf)) {
      for (var puntero = 0; puntero < longitudTokens - ii; puntero++) {
        const fin = ii + puntero + 1;

        let combinacion = tokensInputToArray.slice(puntero, fin).join(" ");

        if (v.find((e) => e === combinacion)) {
          tokensInput = reduceCadena(tokensInput, puntero, fin, k);

          return (tokensInput === "S") ? tokensInput : recorridoCadenaTokens(tokensInput);
        }
      }
    }
  }

  if (longitudTokens === 2) {
    return recorridoCadenaTokens(tokensInput);
  }

  return tokensInput;
}

const archivoTokens = `PRI6 PRV1 ASIG A S D F G H CE13`;
\const lineasSeparadas = archivoTokens.split("\n");

for (const linea of lineasSeparadas) {
  recorridoCadenaTokens(linea);
  console.log("\n");
}