import axios from "axios";
import { Console } from "console";
import { useEffect, useState } from "react";
import { v4 as uuid } from "uuid";
import '../AddEmp/style.css'
import IEmployee from '../IEmployee/IEmployee';
interface props {
  closeEmp: any
}

var image_url: any
var file: string
function AddEmp({ closeEmp }: props) {
  // All the variable initialisation and usestate hooks declaration
  var employees: IEmployee[] = JSON.parse(
    localStorage.getItem("employees") || "[]"
  );
  var [employeeImage, setemployeeImage] = useState<string>("");
  const [employeeFirstname, setemployeeFirstname] = useState<string>("");
  const [employeeLastname, setemployeeLastname] = useState<string>("");
  const [employeePrefferedname, setemployeePrefferedname] = useState<string>(employeeFirstname +" "+ employeeLastname);
  const [employeeJobtitle, setemployeeJobtitle] = useState<string>("Select");
  const [employeeOffice, setemployeeOffice] = useState<string>("Select");
  const [employeeDepartment, setemployeeDepartment] = useState<string>("Select");
  const [employeeSkypeid, setemployeeSkypeid] = useState<string>("");
  const [employeeEmail, setemployeeEmail] = useState<string>("");
  const [employeePhonenumber, setemployeePhonenumber] = useState<number>(0);
  const [alert, setalert] = useState<string>("");
  const [firstNameAlert, setfirstNameAlert] = useState<string>("");
  const [lastNameAlert, setlastNameAlert] = useState<string>("");
  const [departmentNameAlert, setdepartmentNameAlert] = useState<string>("");
  const [jobTitleNameAlert, setjobTitleNameAlert] = useState<string>("");
  const [officeNameAlert, setofficeNameAlert] = useState<string>("");
  const [skypeIdNameAlert, setskypeIdNameAlert] = useState<string>("");
  const [phoneNumberAlert, setphoneNumberAlert] = useState<string>("");
  const [emailAlert, setemailAlert] = useState<string>("");
  const [departments, setdepartments] = useState([]);
  const [offices, setoffices] = useState([]);
  const [jobTitles, setjobTitles] = useState([]);
  /*get method to get all departments from database*/
  useEffect(() => {
    const getEmployesDetails = async () => {
      await axios.get('https://localhost:7055/api/Values/api/Values/TotalDepartments')
        .then((response) => {
          setdepartments(response.data)
        })
        .catch((error) => {
          console.log(error);
        })
    }
    getEmployesDetails();

  }, [])
  /*get method to get all offices from database*/
  useEffect(() => {
    const getEmployesDetails = async () => {
      await axios.get('https://localhost:7055/api/Values/api/Values/TotalOffices')
        .then((response) => {
          setoffices(response.data)
        })
        .catch((error) => {
          console.log(error);
        })
    }
    getEmployesDetails();

  }, [])
   /*get method to get all job titles from database*/
   useEffect(() => {
    const getEmployesDetails = async () => {
      await axios.get('https://localhost:7055/api/Values/api/Values/TotalJobTitles')
        .then((response) => {
          setjobTitles(response.data)
        })
        .catch((error) => {
          console.log(error);
        })
    }
    getEmployesDetails();

  }, [])
  /*function to get all the departments*/
  function displayDepartments() {
    var str = [];
    for (var k=0;k<(departments).length;k++) {
      console.log(k)
      str.push( <option value={departments[k]}>{departments[k]}</option>)
    }
    return str;
  }
    /*function to get all the offices*/
    function displayOffices() {
      var str = [];
      for (var k=0;k<(offices).length;k++) {
        console.log(k)
        str.push( <option  value={offices[k]}>{offices[k]}</option>)
      }
      return str;
    }
  /*function to get all the job titles*/
  function displayJobTitles() {
    var str = [];
    for (var k=0;k<(jobTitles).length;k++) {
      console.log(k)
      str.push( <option  className="dropdown-options" value={jobTitles[k]}>{jobTitles[k]}</option>)
    }
    return str;
  }   
 

  //Function to validate employee details from add employee form
  function validateEmp(): boolean {
    if (employeeFirstname.length == 0) {
      setfirstNameAlert("please enter your first name");
      //return false;
    }
    if (employeeLastname.length == 0) {
      setlastNameAlert("please enter your last name");
      //return false;
    }

    if (employeeDepartment == "Select") {
      setdepartmentNameAlert("please select the department");
      //return false;
    }
    if (employeeJobtitle == "Select") {
      setjobTitleNameAlert("please select the job title");
      //return false;
    }
    if (employeeOffice == "Select") {
      setofficeNameAlert("please select the employeeOffice");
      //return false;
    }
    if (employeeSkypeid.length == 0) {
      setskypeIdNameAlert("please enter employeeSkypeid");
      //return false;
    }
    if (employeePhonenumber?.toString().length != 10) {
      setphoneNumberAlert("please enter the valid phone number");
      //return false;
    }


    var x = employeeEmail;
    var employeeEmail_regex: RegExp = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    if (employeeEmail_regex.test(x) == false) {
      setemailAlert("Please enter a valid employeeEmail ID !");

      //return false;
    }

    return true;
  }

  function previewFile(event: any) {
    var file = event.target.files[0];
    const reader = new FileReader();

    reader.onloadend = (e) => {
      image_url = reader.result;

    }
    if (file) {
      reader.readAsDataURL(file);
    }
  }

  const addEmpBackend = async () => {
    //console.log("charan")
    let validate_res: boolean = validateEmp();
    if (validate_res) {
      employeeImage = image_url;
      await axios.post('https://localhost:7055/api/Values',
        {
          "employeeId": uuid().toString(),
          "firstName": employeeFirstname,
          "lastName": employeeLastname,
          "prefferedName": employeePrefferedname,
          "email": employeeEmail,
          "jobTitleId": employeeJobtitle,
          "officeId": employeeOffice,
          "departmentId": employeeDepartment,
          "contactNumber": employeePhonenumber,
          "skypeId": employeeSkypeid,
          "image": employeeImage.toString()

        }

      )
        .then(e => console.log(e))
        .catch(error => console.log(error))
      closeEmp(false)
      window.location.reload();
      //console.log(JSON.stringify(obj))
    }
  }


  return (
    <div id="add-emp-list" className="adding-employee position-absolute">
      <button className="close-form position-relative" onClick={() => closeEmp(false)}>Close Form</button>
      <h1 className="form-title position-relative">ADD EMPLOYEE</h1>
      <form action="POST">

        <label htmlFor="select_img" className="form-field position-relative"><b>Select Image</b></label>
        <input type="file" className="form-control form-field-value" id="image-input" name="imageurl" onChange={(event) => previewFile(event)} accept="image/jpeg, image/png, image/jpg" />

        <label htmlFor="First_name" className="form-field position-relative"><b>First Name</b></label>
        <input type="text" name="First_name" className="form-field-value" value={employeeFirstname}
        
          onChange={(event) => {
            setemployeeFirstname(event.target.value);
            setemployeePrefferedname(event.target.value+" "+employeeLastname);
           
          }} />
        <p id="alert-msg" className="alert-message font-styles">{firstNameAlert}</p>
        <label htmlFor="Last_name" className="form-field position-relative" ><b>Last Name</b></label>
        <input type="text" name="Last_name" className="form-field-value" value={employeeLastname}
          onChange={(event) =>{ setemployeeLastname(event.target.value);setemployeePrefferedname(employeeFirstname+" "+event.target.value);}} />
        <p id="alert-msg" className="alert-message font-styles">{lastNameAlert}</p>
        <label htmlFor="Prefrd_name" className="form-field position-relative"><b>Preferred Name</b></label>
        <input type="text" name="employeePrefferedname" className="form-field-value" value={employeePrefferedname}
          //onMouseOver={() => setemployeePrefferedname(employeeFirstname + employeeLastname)}
          onChange={(event) => setemployeePrefferedname(event.target.value)} />

        <label htmlFor="Job_title" className="form-field position-relative"><b>Job Title</b></label>
        <select name="Job_title" id="jb-title" className="form-field-value" value={employeeJobtitle}
          onChange={(event) => setemployeeJobtitle(event.target.value)} >
          <option className="dropdown-options" value="Select">Select</option>
          {displayJobTitles()}
        </select>
        <p id="alert-msg" className="alert-message font-styles">{jobTitleNameAlert}</p>
        <label htmlFor="employeeOffice" className="form-field position-relative"><b>employeeOffice</b></label>
        <select name="employeeOffice" id="employeeOffice" className="form-field-value" value={employeeOffice}
          onChange={(event) => setemployeeOffice(event.target.value)} >
          <option className="dropdown-options" value="Select">Select</option>
          {displayOffices()}
        </select>
        <p id="alert-msg" className="alert-message font-styles">{officeNameAlert}</p>
        <label htmlFor="employeeDepartment" className="form-field position-relative"><b>Department</b></label>
        <select name="employeeDepartment" id="employeeDepartment" className="form-field-value" value={employeeDepartment}
          onChange={(event) => setemployeeDepartment(event.target.value)}>
          <option className="dropdown-options" value="Select">Select</option>
          {displayDepartments()}
        </select>
        <p id="alert-msg" className="alert-message font-styles">{departmentNameAlert}</p>
        <label htmlFor="Skype" className="form-field position-relative"><b>Skype ID</b></label>
        <input type="text" name="Skype" className="form-field-value" value={employeeSkypeid}
          onChange={(event) => setemployeeSkypeid(event.target.value)} />
        <p id="alert-msg" className="alert-message font-styles">{skypeIdNameAlert}</p>
        <label htmlFor="employeeEmail" className="form-field"><b>employeeEmail</b></label>
        <input type="email" name="employeeEmail" className="form-field-value" value={employeeEmail}
          onChange={(event) => setemployeeEmail(event.target.value)} />
        <p id="alert-msg" className="alert-message font-styles">{emailAlert}</p>
        <label htmlFor="Phn_no" className="form-field"><b>Phone No</b></label>
        <input
          type="number"
          name="Phn_no"
          className="form-field-value"
          pattern="[0-9]{2}[0-9]{10}"
          placeholder="91xxxxxxxxxx"
          value={employeePhonenumber}
          onChange={(event) => setemployeePhonenumber(event.target.valueAsNumber)}
        />
        <p id="alert-msg" className="alert-message font-styles">{phoneNumberAlert}</p>
        <input
          type="button"
          className="button font-styles employee-submit-button"
          onClick={() => {
            //addEmp()
            addEmpBackend()
          }}
          value="Add Employee"
        />
      </form>
    </div>
  )
}
export default AddEmp