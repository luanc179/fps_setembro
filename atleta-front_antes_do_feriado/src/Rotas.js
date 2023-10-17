import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Atleta from "./components/Atleta";

const Rotas = () => {
    return (<BrowserRouter>
    <Routes>
      <Route path='/' element={<Atleta />} />
      <Route path='atleta' element={<Atleta />}>
        <Route path=':acao' element={<Atleta />} />
        <Route path=':acao/:id' element={<Atleta />} />
      </Route>
    </Routes>
  </BrowserRouter>);
};

export default Rotas;
