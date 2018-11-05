function handleError(errorCode) {
    switch (errorCode) {
        case 0:
            alert("User already exist,Please Login");
            break;
        case 1:
            alert("Login Failed,Please try again");
            break;

        default:
            alert("Something is not went right,Please try again");
            break;
    }

    return false;
}

function complete() {
    console.log("completed");
}