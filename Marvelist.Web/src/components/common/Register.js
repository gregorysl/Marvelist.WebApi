import React from "react";
import { connect } from "react-redux";
import { registerRequest } from "../../actions/userActions";
import { useFormik } from "formik";
import { useHistory } from "react-router-dom";
import { TextField, Button } from "@material-ui/core";

const validate = (values) => {
  const errors = {};
  const reqField = "Field is required!";

  if (!values.email) {
    errors.email = reqField;
  } else if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(values.email)) {
    errors.email = "Invalid email address";
  }
  if (!values.username) {
    errors.username = reqField;
  }

  if (!values.password) {
    errors.password = reqField;
  }
  if (!values.passwordConfirm) {
    errors.passwordConfirm = reqField;
  }
  if (values.password !== values.passwordConfirm) {
    const noMatch = "Passwords don't match";
    errors.passwordConfirm = noMatch;
    errors.password = noMatch;
  }

  return errors;
};
const Register = ({ register, user }) => {
  const history = useHistory();
  const formik = useFormik({
    initialValues: {
      email: "",
      username: "",
      password: "",
      passwordConfirm: "",
    },
    onSubmit: (values) =>
      register(values.email, values.username, values.password),
    validate,
  });

  if (user.loggedIn) {
    history.push("/");
  }

  return (
    <form onSubmit={formik.submitForm}>
      <TextField
        variant="outlined"
        margin="normal"
        required
        fullWidth
        label="E-mail"
        error={formik.errors.username && formik.touched.username}
        helperText={formik.touched.username && formik.errors.username}
        {...formik.getFieldProps("email")}
      />
      <TextField
        variant="outlined"
        margin="normal"
        required
        fullWidth
        label="Username"
        error={formik.errors.username && formik.touched.username}
        helperText={formik.touched.username && formik.errors.username}
        {...formik.getFieldProps("username")}
      />
      <TextField
        variant="outlined"
        margin="normal"
        required
        fullWidth
        label="Password"
        type="password"
        error={formik.errors.password && formik.touched.password}
        helperText={formik.touched.password && formik.errors.password}
        {...formik.getFieldProps("password")}
      />
      <TextField
        variant="outlined"
        margin="normal"
        required
        fullWidth
        label="Confirm Password"
        type="password"
        error={formik.errors.passwordConfirm && formik.touched.passwordConfirm}
        helperText={
          formik.touched.passwordConfirm && formik.errors.passwordConfirm
        }
        {...formik.getFieldProps("passwordConfirm")}
      />
      <Button
        type="submit"
        variant="contained"
        color="primary"
        onClick={formik.submitForm}
      >
        Register
      </Button>
    </form>
  );
};

const mapStateToProps = (state) => {
  return {
    user: state.user,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    register: (email, username, password) =>
      dispatch(registerRequest({ email, username, password })),
  };
};

const WrappedNormalLoginForm = connect(
  mapStateToProps,
  mapDispatchToProps
)(Register);

export default WrappedNormalLoginForm;
