import axios from "axios";
import React from "react";

import { ListView } from './view/ListView';


const baseURL = "http://localhost:5164/Muffin";


export default function App() {
    const [muffins, setMuffins] = React.useState(null);

    React.useEffect(() => {
        axios.get(baseURL).then((response) => {
            setMuffins(response.data);
console.log(muffins)
        });
    }, []);
    if (!muffins) return null;

    return (
    <div>
          {ListView(muffins)}
    </div>

    );
}