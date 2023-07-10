function validarCns(cns) {
    if (cns == null || cns.trim().length != 15) {
        return false;
    }

    //1. Rotina de validação de Números que iniciam com 1 ou 2:
    if (cns.startsWith("1") || cns.startsWith("2")) {
        let soma;
        let resto, dv;
        let pis = "";
        let resultado = "";
        pis = cns.substring(0, 11);

        soma = (parseInt(cns.substring(0, 1)) * 15) +
            (parseInt(cns.substring(1, 2)) * 14) +
            (parseInt(cns.substring(2, 3)) * 13) +
            (parseInt(cns.substring(3, 4)) * 12) +
            (parseInt(cns.substring(4, 5)) * 11) +
            (parseInt(cns.substring(5, 6)) * 10) +
            (parseInt(cns.substring(6, 7)) * 9) +
            (parseInt(cns.substring(7, 8)) * 8) +
            (parseInt(cns.substring(8, 9)) * 7) +
            (parseInt(cns.substring(9, 10)) * 6) +
            (parseInt(cns.substring(10, 11)) * 5);

        //1º teste
        resto = soma % 11;
        dv = 11 - resto;

        //2º teste
        if (dv == 11) {
            dv = 0;
        }

        //3º teste
        if (dv == 10) {
            soma += 2;

            resto = soma % 11;
            dv = 11 - resto;
            resultado = pis + "001" + dv.toString();
        }
        else {
            resultado = pis + "000" + dv.toString();
        }

        return cns == resultado;
    }


    //2. Rotina de validação de Números que iniciam com 7, 8 ou 9:
    if (cns.startsWith("7") || cns.startsWith("8") || cns.startsWith("9")) {
        let resto, soma;

        soma = (parseInt(cns.substring(0, 1)) * 15) +
            (parseInt(cns.substring(1, 2)) * 14) +
            (parseInt(cns.substring(2, 3)) * 13) +
            (parseInt(cns.substring(3, 4)) * 12) +
            (parseInt(cns.substring(4, 5)) * 11) +
            (parseInt(cns.substring(5, 6)) * 10) +
            (parseInt(cns.substring(6, 7)) * 9) +
            (parseInt(cns.substring(7, 8)) * 8) +
            (parseInt(cns.substring(8, 9)) * 7) +
            (parseInt(cns.substring(9, 10)) * 6) +
            (parseInt(cns.substring(10, 11)) * 5) +
            (parseInt(cns.substring(11, 12)) * 4) +
            (parseInt(cns.substring(12, 13)) * 3) +
            (parseInt(cns.substring(13, 14)) * 2) +
            (parseInt(cns.substring(14, 15)) * 1);


        resto = soma % 11;

        return resto == 0;
    }

    //se for 3, 4, 5 ou 6 é inválido
    return false;
}