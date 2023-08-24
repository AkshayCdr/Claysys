const form = document.querySelector("form");
const nameInput = document.getElementById("name");
const emailInput = document.getElementById("email");

form.addEventListener("submit", (e) => {
  e.preventDefault();

  validateForm();
});

const setError = (element, message) => {
  const errorDisplay = document.getElementById(`${element.id}-error`);
  errorDisplay.innerText = message;
  element.classList.add("error-message");
};

const setSuccess = (element) => {
  const errorDisplay = document.getElementById(`${element.id}-error`);
  errorDisplay.innerText = "";
  element.classList.remove("error-message");
};

const isValidEmail = (email) => {
  const re =
    /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  return re.test(String(email).toLowerCase());
};

const validateForm = () => {
  const nameValue = nameInput.value.trim();
  const emailValue = emailInput.value.trim();

  if (nameValue === "") {
    setError(nameInput, "Name is required");
  } else {
    setSuccess(nameInput);
  }

  if (emailValue === "") {
    setError(emailInput, "Email is required");
  } else if (!isValidEmail(emailValue)) {
    setError(emailInput, "Provide a valid email address");
  } else {
    setSuccess(emailInput);
    // If both name and email are valid, you can submit the form here
    // form.submit();
  }
};
