window.addEventListener("load", function () {
    console.log("Window and assosciated scripts loaded successfully")

    let vitalTable = document.getElementById("vitals-table")
    let heartData = document.getElementById("vitalHeartRate")
    let systolicData = document.getElementById("vitalSystolic")
    let diastolicData = document.getElementById("vitalDiastolic")

    for (let i = 0, cell; cell = vitalTable.rows[i]; i++) {
        if (Number(heartData.innerText) > 135) {
            heartData.style.color = 'red';
        } else if (Number(heartData.innerText) < 60) {
            heartData.style.color = 'dodgerblue'
        }

        if (Number(systolicData.innerText) > 175) {
            systolicData.style.color = 'red';
        } else if (Number(systolicData.innerText) < 90) {
            systolicData.style.color ='dodgerblue'
        }

        if (Number(diastolicData.innerText) > 92) {
            diastolicData.style.color = 'red';
        } else if (Number(diastolicData.innerText) < 60) {
            diastolicData.style.color = 'dodgerblue'
        }
    }

    let vitalSubmit = document.getElementById("vitalSubmit");

    vitalSubmit.addEventListener("submit", ()=>checkVitalSigns(event));

    function checkVitalSigns(event) {
        console.log("Hello world!")
        let systolic = document.querySelector("#systolic");
        let diastolic = document.querySelector("#diastolic");
        let heartRate = document.querySelector("#heartRate");

        if (Number(systolic.value) > 175) {
            window.alert("Your systolic blood pressure is high! Please retake your blood pressure again in 5 minutes and call your doctor");
        } else if (Number(systolic.value) < 90) {
            window.alert("Your systolic blood pressure is low! Please retake your blood pressure again in 5 minutes and call your doctor");
        }

        if (Number(diastolic.value) > 95) {
            window.alert("Your diastolic blood pressure is high! Please retake your blood pressure again in 5 minutes and call your doctor");
        } else if (Number(diastolic.value) < 60) {
            window.alert("Your diastolic blood pressure is low! Please retake your blood pressure again in 5 minutes and call your doctor");
        }

        if (Number(heartRate.value) > 130) {
            window.alert("Your heart rate is high! Please retake your blood pressure again in 5 minutes and call your doctor");
        } else if (Number(heartRate.value) < 50) {
            window.alert("Your heart rate is low! Please retake your blood pressure again in 5 minutes and call your doctor");
        }

    }

})





