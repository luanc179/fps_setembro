import React, {useState, useEffect} from "react";
import CrudAcao from "./CrudAcao";
import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";

const CrudManutencao = (props) => {
    const [objeto, setObjeto] = useState(null);
    const [carregando, setCarregando] = useState(true);
    const navigate = useNavigate();
    
    const tratarClique = (e) => {
        e.preventDefault();
        if (props.acao === CrudAcao.inserir) {
            props.inserir(objeto);
        } else if (props.acao === CrudAcao.alterar) {
            props.alterar(objeto);
        } else if (props.acao === CrudAcao.excluir) {
            props.excluir(objeto.id);
        }

        navigate(`/${props.entidade}`);
    };

    const getBotaoAcao = () => {
        if (props.acao === CrudAcao.inserir) {
            return <button className="btn btn-primary" onClick={tratarClique}>Salvar</button>
        } else if (props.acao === CrudAcao.alterar) {
            return <button className="btn btn-warning" onClick={tratarClique}>Salvar</button>
        } else if (props.acao === CrudAcao.excluir) {
            return <button className="btn btn-danger" onClick={tratarClique}>Excluir</button>
        } else {
            return null;
        }
    }

    const alterarCampo = (nome, valor) => {
        let objNovo = {...objeto};
        objNovo[nome] = valor;
        setObjeto(objNovo);
    };

    useEffect(() => {
        if (props.acao === CrudAcao.inserir) {
            setObjeto(props.novoObjeto());
            setCarregando(false);
        }
        else {

            props.retornarPorId(props.id, (obj => {
                setObjeto(obj);
                setCarregando(false);
            }));            
        }
    }, [carregando]);

    if (carregando) {
        return <div>Carregando...</div>;
    }

    return (
        <div>
            <h3 className={props.acao === CrudAcao.excluir ? "text-danger" : ""}>{getTitulo(props.acao, props.entidadeNomeAmigavel)}</h3>
            <form>
                {props.campos(props.acao === CrudAcao.consultar, objeto, alterarCampo)}
                <div>
                    {getBotaoAcao()}
                    <Link className="btn btn-secondary" to={`/${props.entidade}`}>Voltar</Link>
                </div>
            </form>
        </div>
    );
};

const getTitulo = (acao, entidadeNomeAmigavel) => {
    let acaoNome;
    
    if (acao === CrudAcao.alterar) {
        acaoNome = "Alterando";
    } else if (acao === CrudAcao.consultar) {
        acaoNome = "Consultando";
    }else if (acao === CrudAcao.inserir) {
        acaoNome = "Inserindo";
    } else if (acao === CrudAcao.excluir) {
        acaoNome = "Excluindo";
    } else {
        acaoNome = "";
    }

    return `${acaoNome} ${entidadeNomeAmigavel}`;
};

export default CrudManutencao;
