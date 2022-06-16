import React from 'react'

    const PersonRow = ({person})=> {        
    const {id,firstName, lastName, age, address, email} = person
    {console.log(person)}
        return (
                <tr>
                    <td>{id}</td>
                    <td>{firstName}</td>
                    <td>{lastName}</td>
                    <td>{age}</td>
                    <td>{address}</td>
                    <td>{email}</td>
                </tr>
        )
    
}

export default PersonRow;