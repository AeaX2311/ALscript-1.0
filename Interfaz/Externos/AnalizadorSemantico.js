const fs = require("fs");

const gramaticasIf = {
  CON: [
    "CON CON",
    "IN_ASIGNACION",
    "IN_IO",
    "IN_COMENTARIO",
    "IN_CONTINUAR",
    "IN_CONTINUAR CON",
    "CON IN_CONTINUAR",
    "CON IN_CONTINUAR CON",
    "IN_ROMPER",
    "IN_ROMPER CON",
    "CON IN_ROMPER",
    "CON IN_ROMPER CON",
    "IN_SEGUN IN_PARINI IN_CASO IN_PARFIN",
    "IN_SI CON IN_PARFIN",
    
    "IN_CICLO CON IN_PARFIN",

    "IN_SI IN_PARINI CON IN_PARFIN",
    "IN_SI IN_PARINI CON IN_PARMIDLE IN_SINO IN_PARINI CON IN_PARFIN",
    "IN_HACER IN_PARINI CON IN_PARMIDLE IN_MIENTRAS",
    "IN_SI IN_PARINI CON IN_SINO CON IN_PARFIN"
  ],

  IN_CASO: [
    "IN_CASO CON",
    "IN_CASO IN_CASO"
  ],

  CONSTENT: [
    "CONSTENT OPA1 CONSTENT",
    "CONSTENT OPA2 CONSTENT",
    "CONSTENT OPA3 CONSTENT",
    "CONSTENT OPA4 CONSTENT",
    "CONSTENT OPA5 CONSTENT",
    "CONSTENT OPA6 CONSTENT",
],

CONSTRE: [
    "CONSTRE OPA1 CONSTRE",
    "CONSTRE OPA2 CONSTRE",
    "CONSTRE OPA3 CONSTRE",
    "CONSTRE OPA4 CONSTRE",

    "CONSTRE OPA1 CONSTENT",
    "CONSTRE OPA2 CONSTENT",
    "CONSTRE OPA3 CONSTENT",
    "CONSTRE OPA4 CONSTENT",

    "CONSTENT OPA1 CONSTRE",
    "CONSTENT OPA2 CONSTRE",
    "CONSTENT OPA3 CONSTRE",
    "CONSTENT OPA4 CONSTRE",
],

CONSTEX: [
    "CONSTEX OPA1 CONSTEX",
    "CONSTEX OPA2 CONSTEX",
    "CONSTEX OPA3 CONSTEX",
    "CONSTEX OPA4 CONSTEX",

    "CONSTEX OPA1 CONSTENT",
    "CONSTEX OPA2 CONSTENT",
    "CONSTEX OPA3 CONSTENT",
    "CONSTEX OPA4 CONSTENT",

    "CONSTEX OPA1 CONSTRE",
    "CONSTEX OPA2 CONSTRE",
    "CONSTEX OPA3 CONSTRE",
    "CONSTEX OPA4 CONSTRE",

    "CONSTENT OPA1 CONSTEX",
    "CONSTENT OPA2 CONSTEX",
    "CONSTENT OPA3 CONSTEX",
    "CONSTENT OPA4 CONSTEX",

    "CONSTRE OPA1 CONSTEX",
    "CONSTRE OPA2 CONSTEX",
    "CONSTRE OPA3 CONSTEX",
    "CONSTRE OPA4 CONSTEX",
],

CADENA: [
    "CADENA OPA1 CADENA",
],

OP_RELACIONAL: [
    //CON ENTEROS
    "CONSTENT OPR1 CONSTENT",
    "CONSTENT OPR2 CONSTENT",
    "CONSTENT OPR3 CONSTENT",
    "CONSTENT OPR4 CONSTENT",
    "CONSTENT OPR5 CONSTENT",
    "CONSTENT OPR6 CONSTENT",

    //CON RELACIONALES
    "CONSTRE OPR1 CONSTRE",
    "CONSTRE OPR2 CONSTRE",
    "CONSTRE OPR3 CONSTRE",
    "CONSTRE OPR4 CONSTRE",
    "CONSTRE OPR5 CONSTRE",
    "CONSTRE OPR6 CONSTRE",

    //CON EXPONENCIALES
    "CONSTEX OPR1 CONSTEX",
    "CONSTEX OPR2 CONSTEX",
    "CONSTEX OPR3 CONSTEX",
    "CONSTEX OPR4 CONSTEX",
    "CONSTEX OPR5 CONSTEX",
    "CONSTEX OPR6 CONSTEX",

    //CADENAS
    "CADENA OPR6 CADENA",

    //LOGICO
    "VAL_BOLEANO OPR6 VAL_BOLEANO",
    "VAL_BOLEANO OPR5 VAL_BOLEANO"
],

PRB1: ["OPL1 PRB2"],

PRB2: ["OPL1 PRB1"],

VAL_BOLEANO: [
    "PRB1 OPL2 PRB1",
    "PRB2 OPL2 PRB1",
    "PRB1 OPL2 PRB2",
    "PRB2 OPL2 PRB2",
    "PRB1 OPL3 PRB1",
    "PRB2 OPL3 PRB1",
    "PRB1 OPL3 PRB2",
    "PRB2 OPL3 PRB2",

    "OPL1 VAL_BOLEANO",
    "VAL_BOLEANO OPL2 VAL_BOLEANO",
    "VAL_BOLEANO OPL3 VAL_BOLEANO",
    "VAL_BOLEANO OPL3 PRB1",
    "VAL_BOLEANO OPL3 PRB2",
    "PRB1 OPL3 VAL_BOLEANO",
    "PRB2 OPL3 VAL_BOLEANO",
    "VAL_BOLEANO OPL2 PRB1",
    "VAL_BOLEANO OPL2 PRB2",
    "PRB1 OPL2 VAL_BOLEANO",
    "PRB2 OPL2 VAL_BOLEANO",

    "PRB1",
    "PRB2",
    
    //para operaciones relacionales
    "OPL1 OP_RELACIONAL",
    "OP_RELACIONAL OPL2 OP_RELACIONAL",
    "OP_RELACIONAL OPL3 OP_RELACIONAL",
    
    //para cierto PRB1 PRB2 
    "PRB1 OPL2 OP_RELACIONAL",
    "OP_RELACIONAL OPL2 PRB1",
    "PRB1 OPL3 OP_RELACIONAL",
    "OP_RELACIONAL OPL3 PRB1",

    //para falso
    "PRB2 OPL2 OP_RELACIONAL",
    "OP_RELACIONAL OPL2",
    "PRB2 OPL3 OP_RELACIONAL",
    "OP_RELACIONAL OPL3",
  ],
  
  S: [
    "PRINI CON PRFIN",
    "CONSTENT",
    "CONSTRE",
    "CONSTEX",
    "CADENA",
    "OP_RELACIONAL",
    "VAL_BOLEANO",
  ],
};

let evaluacionSemantica = "";
const reduceCadena = (origen, puntero, fin, nuevo) => {
  const origenTokens = origen.split(" ");
  return origenTokens
    .slice(0, puntero)
    .concat([`${nuevo}`])
    .concat(origenTokens.slice(fin, origenTokens.length))
    .join(" ");
};

function recorridoCadenaTokens(tokensInput) {
  let tokensInputToArray = tokensInput.split(" "), longitudTokens = tokensInputToArray.length;    
  evaluacionSemantica += "-->  " + tokensInput + "\n";

  for (let contLongitud = longitudTokens - 1; contLongitud >= 0; contLongitud--) {
    for (const [k, v] of Object.entries(gramaticasIf)) {
      for (let puntero = 0; puntero < longitudTokens - contLongitud; puntero++) {
        const fin = contLongitud + puntero + 1;
        if (v.find((e) => e === tokensInputToArray.slice(puntero, fin).join(" "))) {
          tokensInput = reduceCadena(tokensInput, puntero, fin, k);
          return tokensInput.trim() === "S" ? tokensInput : recorridoCadenaTokens(tokensInput);
        }
      }
    }
  }

  return tokensInput;
}

fs.readFile("sintaxisTokens.tmpalscript", "utf-8", (err, data) => {
  if (!err) {
    const repairedData = data.replace(/[\r]+/g, '').trimEnd();
    const manipulableData = repairedData.split("\n");
    
    //console.log(manipulableData);
    
    for (const linea of manipulableData) {
      if(linea === '') continue;

      if (recorridoCadenaTokens(linea).trim() === "S"){
        evaluacionSemantica += "-->  S\n\n";
      } else {
        evaluacionSemantica += "-->  ERR\n\n";
      }       
    }

    fs.writeFile(
      "semanticaResult.tmpalscript",
      evaluacionSemantica.trimEnd(),
      (err) => {
        if (err) {
          console.error("Algo sucedio");
        }
      }
    );
  }
});