import React from "react";
import { connect } from "react-redux";
import { loginRequest } from "../../actions/userActions";
import { useFormik } from "formik";
import { useHistory } from "react-router-dom";
import { Grid, Link, TextField, Button } from "@material-ui/core";

const validate = (values) => {
  const errors = {};
  const reqField = "Field is required!";
  if (!values.username) {
    errors.username = reqField;
  }

  if (!values.password) {
    errors.password = reqField;
  }
  return errors;
};
const Login = ({ login, data }) => {
  const history = useHistory();
  const formik = useFormik({
    initialValues: { username: "", password: "" },
    onSubmit: (values) => {
      login(values.username, values.password);
    },
    validate,
  });
  if (data.loggedIn) {
    history.push("/");
  }
  return (
    <>
      <TextField
        variant="outlined"
        margin="normal"
        required
        fullWidth
        label="Username"
        name="username"
        error={formik.errors.username && formik.touched.username}
        helperText={formik.touched.username && formik.errors.username}
        {...formik.getFieldProps("username")}
      />
      <TextField
        variant="outlined"
        margin="normal"
        required
        fullWidth
        name="password"
        label="Password"
        type="password"
        error={formik.errors.password && formik.touched.password}
        helperText={formik.touched.password && formik.errors.password}
        {...formik.getFieldProps("password")}
      />
      <Button
        type="submit"
        variant="contained"
        color="primary"
        onClick={formik.submitForm}
      >
        Sign In
      </Button>
      <Grid container>
        <Grid item xs>
          <Link href="#" variant="body2">
            Forgot password?
          </Link>
        </Grid>
        <Grid item>
          <Link href="#" variant="body2">
            {"Don't have an account? Sign Up"}
          </Link>
        </Grid>
      </Grid>
    </>
  );
};

const mapStateToProps = (state) => {
  return {
    data: state.user,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    login: (username, password) =>
      dispatch(loginRequest({ username, password })),
  };
};

const WrappedNormalLoginForm = connect(
  mapStateToProps,
  mapDispatchToProps
)(Login);

export default WrappedNormalLoginForm;
