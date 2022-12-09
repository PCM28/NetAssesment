import React from "react";
import { useNavigate } from "react-router-dom";

function AddReference(props) {
  const navigate = useNavigate();
  function handleOnClick() {
    const url = props.url + props.id;
    navigate(url);
  }
  return <button onClick={handleOnClick}>{props.value}</button>;
}

export default AddReference;
