const form = document.getElementById("form");
const firstName = document.getElementById("first-name");
const dob = document.getElementById("date-of-birth");
const Age = document.getElementById("age");
const phoneNumber = document.getElementById("phone-number");
const email = document.getElementById("email");
// const gender = document.getElementsByName("gender");
const state = document.getElementById("state");
const city = document.getElementById("city");
const userName = document.getElementById("username");
const password = document.getElementById("password");
const confrPass = document.getElementById("confirm-password");
const btn = document.getElementById("btn");

form.addEventListener("submit", (e) => {
  e.preventDefault();

  validateInputs();
});

const setError = (element, message) => {
  const inputControl = element.parentElement;
  const errorDisplay = inputControl.querySelector(".error");

  errorDisplay.innerText = message;
  inputControl.classList.add("error");
  inputControl.classList.remove("success");
};

const setSuccess = (element) => {
  const inputControl = element.parentElement;
  const errorDisplay = inputControl.querySelector(".error");

  errorDisplay.innerText = "";
  inputControl.classList.add("success");
  inputControl.classList.remove("error");
};

const isValidEmail = (email) => {
  const re =
    /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  return re.test(String(email).toLowerCase());
};

const validateInputs = () => {
  const firstNameValue = firstName.value.trim();
  const dobValue = dob.value.trim();
  const ageValue = Age.value.trim();
  const phoneValue = phoneNumber.value.trim();
  const emailValue = email.value.trim();

  const stateValue = state.value.trim();
  const cityValue = city.value.trim();
  const usernameValue = userName.value.trim();
  const passwordValue = password.value.trim();
  const password2Value = confrPass.value.trim();

  if (firstNameValue === "") {
    setError(firstName, "firstname is required");
  } else {
    setSuccess(firstName);
  }

  if (dobValue === "") {
    setError(dob, "dob is required");
  } else {
    setSuccess(dob);
  }

  if (ageValue === "") {
    setError(Age, "age required");
  } else if (ageValue <= 0 || ageValue >= 130) {
    setError(Age, "invalid age");
  } else {
    setSuccess(Age);
  }

  //   let genderSelected = false;
  //   for (let i = 0; i < gender.length; i++) {
  //     if (gender[i].checked) {
  //       genderSelected = true;
  //       break;
  //     }
  //   }

  //   const radios = document.getElementsByClassName("radio-group");

  //   if (!genderSelected) {
  //     setError(radios, "Please select a gender");
  //   } else {
  //     setSuccess(radios);
  //   }

  const length = phoneValue.length;

  if (length === "") {
    setError(phoneNumber, "Phone number required");
  } else if (length !== 10) {
    setError(phoneNumber, "invalid number");
  } else {
    setSuccess(phoneNumber);
  }

  if (emailValue === "") {
    setError(email, "Email is required");
  } else if (!isValidEmail(emailValue)) {
    setError(email, "Provide a valid email address");
  } else {
    setSuccess(email);
  }

  if (stateValue === "") {
    setError(state, "state is required");
  } else {
    setSuccess(state);
  }

  if (cityValue === "") {
    setError(city, "city is required");
  } else {
    setSuccess(city);
  }

  if (usernameValue === "") {
    setError(userName, "uesrname is required");
  } else {
    setSuccess(userName);
  }

  if (passwordValue === "") {
    setError(password, "Password is required");
  } else if (passwordValue.length < 8) {
    setError(password, "Password must be at least 8 character.");
  } else {
    setSuccess(password);
  }

  if (password2Value === "") {
    setError(confrPass, "Please confirm your password");
  } else if (password2Value !== passwordValue) {
    setError(confrPass, "Passwords doesn't match");
  } else {
    setSuccess(confrPass);
  }
};
