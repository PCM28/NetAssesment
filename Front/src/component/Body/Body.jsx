import React from "react";
import Claims from "../../pages/Claims/Claims";
import Vehicles from "../../pages/Vehicles/Vehicles";
import Owner from "../../pages/Owner/Owner";
import { Route, Routes } from "react-router-dom";
import { useState } from "react";
import axios from "axios";

function Body() {
  
  const urlClaim = "https://localhost:7157/api/Claims";

  function getAllData(){
    axios.get(urlClaim).then(response => setClaims(response.data))
  }


  const [claims,setClaims]= useState([])

  
  React.useEffect(getAllData,[claims])
  return (
    <Routes>
      <Route path="*" element={<Owner ></Owner>}></Route>
      <Route path="/owner" element={<Owner ></Owner>}></Route>
      <Route path="/vehicles/:id" element={<Vehicles ></Vehicles>}></Route>
      <Route path="/claims/:id" element={<Claims></Claims>}></Route>
    </Routes>
  );
}

export default Body;
