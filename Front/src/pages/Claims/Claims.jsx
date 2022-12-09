import React from "react";
import { useParams } from "react-router-dom";
import Table from "../../component/Table/Table";

function Claims(props) {
  const { id } = useParams();
  const object = { Vehicle_id: id };
  const headers = ["idClaim", "description", "status", "idVehicle"];
  return (
    <div>
      <h1>Claims</h1>
      <Table
        headers={headers}
        elements={props.elements}
        setElements={props.setElements}
        object={object}
        id={id}
        property="Vehicle_id"
        service={"Claims"}
      ></Table>
    </div>
  );
}

export default Claims;
