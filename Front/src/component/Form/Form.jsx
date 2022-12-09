import React, { useState } from "react";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Field from "../Field/Field";

function Form(props) {
  const [object, setObject] = useState(props.object);
  const transferValue = (event) => {
    event.preventDefault();
    props.func(object);
    setObject(props.object);
  };

  return (
    <Box
      component="form"
      sx={{
        "& .MuiTextField-root": { m: 1, width: "25ch" },
      }}
      noValidate
      autoComplete="off"
    >
      <div>
        {props.headers.map((header, index) => (
          <Field
            key={`${header}${index}`}
            id={`${header}${index}`}
            label={header}
            object={object}
            setObject={setObject}
          />
        ))}

        <Button sx={{ m: 2 }} variant="outlined" onClick={transferValue}>
          SUBMIT
        </Button>
      </div>
    </Box>
  );
}

export default Form;
