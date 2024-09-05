import { objectToQueryString } from "../../shared/util/formatConverter.js ";
import { API } from "../config/config.js"

export async function selectSaleApi(payload) {
    const queryString = objectToQueryString(payload);
    const URL = `${API.SELECT_SALE_URL}?${queryString}`;

    try {
        const response = await fetch(URL, {
            method: 'GET'
        });
        return response.json();
    }
    catch {

    }
    finally {

    }
}