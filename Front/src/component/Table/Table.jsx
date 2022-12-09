import React from "react";
import Stack from "@mui/material/Stack";
import Form from "../Form/Form";
import EditValue from "../EditValue/EditValue";
import AddReference from "../AddReference/AddReference";
import axios from "axios"

function Table(props) {
  const url= "https://localhost:7157/api/"+props.service;
  const tableRows = props.elements
    .filter((element) => {
      if (element[props.property] === undefined) {
        return true;
      }
      return element[props.property] === props.id;
    })
    .map((info) => {
      return (
        <tr key={info.id}>
          {props.headers.map((header, index) => (
            <td key={index}>
              <EditValue
                value={info[`${header}`]}
                element={info}
                property={header}
                url={url}
              />
            </td>
          ))}
          <td>
            {props.addButton !== undefined ? (
              <AddReference
                value={props.addButton}
                id={info.ID}
                url={props.url}
              />
            ) : (
              ""
            )}
          </td>
        </tr>
      );
    });

  const addRows = (data) => {
    const totalUsers = props.elements.length;
    data.ID = totalUsers + 1;
    axios.post(url,data)
    const updatedUserData = [...props.elements];
    updatedUserData.push(data);
    props.setElements(updatedUserData);
  };

  return (
    <div>
      <Stack sx={{ m: 4 }}>
        <Form func={addRows} headers={props.headers} object={props.object} />
      </Stack>
      <Stack sx={{ m: 2 }}>
        <table className="table table-stripped">
          <thead>
            <tr>
              {props.headers.map((header, index) => (
                <th key={index}>{header}</th>
              ))}
            </tr>
          </thead>
          <tbody>{tableRows}</tbody>
        </table>
      </Stack>
    </div>
  );
}

export default Table;
