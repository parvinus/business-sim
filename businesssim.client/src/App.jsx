import { useEffect, useState } from 'react';
import {Card, CardBody} from "@nextui-org/react";
import './App.css';
import {
    Table,
    TableHeader,
    TableBody,
    TableColumn,
    TableRow,
    TableCell
  } from "@nextui-org/table";

function App() {
    const [forecasts, setForecasts] = useState();

    useEffect(() => {
        populateWeatherData();
    }, []);

    const contents = forecasts === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <Table className="table table-striped" aria-labelledby="tableLabel">
            <TableHeader>
                <TableColumn>Date</TableColumn>
                <TableColumn>Temp (C)</TableColumn>
                <TableColumn>Temp. (F)</TableColumn>
                <TableColumn>Summary</TableColumn>
            </TableHeader>
            <TableBody>
                {forecasts.map(forecast =>
                    <TableRow key={forecast.date}>
                        <TableCell>{forecast.date}</TableCell>
                        <TableCell>{forecast.temperatureC}</TableCell>
                        <TableCell>{forecast.temperatureF}</TableCell>
                        <TableCell>{forecast.summary}</TableCell>
                    </TableRow>
                )}
            </TableBody>
        </Table>;

    return (
        <>
        <h1 id="tableLabel">Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        <Card>
            <CardBody>
                {contents}
            </CardBody>
        </Card>
        </>
    );
    
    async function populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        setForecasts(data);
    }
}

export default App;