import React from "react";
import Table from "../../component/Table/Table";
import axios from "axios";
import { useState } from "react";

function Owner(props) {
  const headers = ["idOwner", "firstName", "lastName", "driverLincese"];
  const url = "/vehicles/";
  const [owners,setOwners]= useState([])
  const object = {};
  const urlOwner = "https://localhost:7157/api/Owners";


  function getOwner(){
    axios.get(urlOwner).then(response => setOwners(response.data))
  }
  React.useEffect(getOwner,[owners])
  return (
    <div>
      <h1>Owners</h1>
      <Table elements={owners} setElements={setOwners}
        headers={headers}
        addButton={"Add Vehicles"}
        url={url}
        object={object}
        service={"Owners"}
      ></Table>
    </div>
  );
}

export default Owner;
