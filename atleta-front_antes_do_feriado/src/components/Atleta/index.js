import React from "react";
import { useParams } from "react-router-dom";
import Crud from "../Crud";

const Atleta = () => {

    const {id, acao} = useParams();
    
    const configCampos = {
        titulos: ['Nome', 'Altura'],
        propriedades: ['nome', 'altura']
    }

    let objetos = [
        { id: '1', nome: 'Ana', altura: 1.6, peso: 50 },
        { id: '2', nome: 'Bruno', altura: 1.9, peso: 80 },
        { id: '3', nome: 'Carlos', altura: 1.8, peso: 80 }
    ];

    return (
        <Crud 
            entidade = "atleta"
            entidadeNomeAmigavel = "Atleta"
            entidadeNomeAmigavelPlural = "Atletas"
            id = {id}
            acao = {acao}
            configCampos = {configCampos}
            objetos={objetos}
        />
    );
};

export default Atleta;
