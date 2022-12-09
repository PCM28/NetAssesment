import React from "react";
import { useParams } from "react-router-dom";
import Table from "../../component/Table/Table";
import axios from "axios";
import { useState } from "react";

function Vehicles(props) {
  const { id } = useParams();
  const object = { Owner_Id: id };
  const url = "/claims/";
  const headers = ["idVehicle", "brand", "vin", "color", "year", "idOwner"];
  const urlVehicle = "https://localhost:7157/api/Vehicles";
  const [vehicles,setVehicles]= useState([])
  function getVehicle(){
    axios.get(urlVehicle).then(response => setVehicles(response.data))
  }
  React.useEffect(getVehicle,[vehicles])
  return (
    <div>
      <h1>Vehicles</h1>
      <Table
        elements={vehicles}
        setElements={setVehicles}
        headers={headers}
        addButton={"Add Claims"}
        url={url}
        object={object}
        id={id}
        property="Owner_Id"
        service={"Vehicles"}
      ></Table>
    </div>
  );
}

export default Vehicles;
