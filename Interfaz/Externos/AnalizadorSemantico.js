const fs = require("fs");

const gramaticasIf = {
  CON: [
    "CON CON",
    "IN_ASIGNACION",
    "IN_IO",
    "IN_SI IN_PARINI CON IN_PARFIN",
    "IN_SI IN_PARINI CON IN_PARMIDLE IN_SINO IN_PARINI CON IN_PARFIN",
    "IN_COMENTARIO",
    "IN_CICLO IN_PARINI CON IN_PARFIN",
    "IN_HACER IN_PARINI CON IN_PARMIDLE IN_MIENTRAS",
    "IN_CONTINUAR",
    "IN_CONTINUAR CON",
    "CON IN_CONTINUAR",
    "CON IN_CONTINUAR CON",
    "IN_ROMPER",
    "IN_ROMPER CON",
    "CON IN_ROMPER",
    "CON IN_ROMPER CON",
    "IN_SEGUN IN_PARINI IN_CASO IN_PARFIN",
    "IN_SI IN_PARINI CON IN_SINO CON IN_PARFIN"//borrar..?
  ],

  IN_CASO: [
    "IN_CASO CON",
    "IN_CASO IN_CASO"
  ],



  S: [
    "PRINI CON PRFIN",




































    "CONSTENT OPA1 CONSTENT"
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
          return tokensInput === "S" ? tokensInput : recorridoCadenaTokens(tokensInput);
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
    console.log(manipulableData);
    for (const linea of manipulableData) {
      if(linea === '') continue;
      if (recorridoCadenaTokens(linea) === "S") evaluacionSemantica += "-->  S\n\n";
      else evaluacionSemantica += "-->  ERR\n\n";
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


// let evaluacionSintaxis = "";
// const reduceCadena = (origen, puntero, fin, nuevo) => {
//   const origenTokens = origen.split(" ");
//   return origenTokens
//     .slice(0, puntero)
//     .concat([`${nuevo}`])
//     .concat(origenTokens.slice(fin, origenTokens.length))
//     .join(" ");
// };

// function recorridoCadenaTokens(tokensInput) {
//   let tokensInputToArray = tokensInput.split(" "),
//     longitudTokens = tokensInputToArray.length;
//     if (tokensInput.substring(0,2) === "IN" || tokensInput.substring(0,1) === "PR")
//     {
//       evaluacionSintaxis += "-->  " + tokensInput + "\n";
//     }

//   for (
//     let contLongitud = longitudTokens - 1;
//     contLongitud >= 0;
//     contLongitud--
//   ) {
//     for (const [k, v] of Object.entries(gramaticasIf)) {
//       for (let puntero = 0; puntero < longitudTokens - contLongitud; puntero++) {
//         const fin = contLongitud + puntero + 1;
//         if (
//           v.find((e) => e === tokensInputToArray.slice(puntero, fin).join(" "))
//         ) {
//           tokensInput = reduceCadena(tokensInput, puntero, fin, k);
//           return tokensInput === "S" ? tokensInput : recorridoCadenaTokens(tokensInput);
//         }
//       }
//     }
//   }

//   return tokensInput;
// }

// fs.readFile("lexicoTokensSemantica.tmpalscript", "utf-8", (err, data) => {
//   if (!err) {
//     const repairedData = data.replace(/[\r]+/g, '').trimEnd();
//     const manipulableData = repairedData.split("\n");
//     console.log(manipulableData);
//     for (const linea of manipulableData) {
//       if(linea === '') continue;
//       if (recorridoCadenaTokens(linea) === "S")
//       {  
//         evaluacionSintaxis += "\n";
//       }
//       else evaluacionSintaxis += "-->  ERR\n\n";
//     }

//     fs.writeFile(
//       "semanticaResult.tmpalscript",
//       evaluacionSintaxis.trimEnd(),
//       (err) => {
//         if (err) {
//           console.error("Algo sucedio");
//         }
//       }
//     );
//   }
// });
