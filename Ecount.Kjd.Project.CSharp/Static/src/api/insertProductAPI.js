import { API } from "../config/config.js"

export async function insertProductApi(requestDto) {
const URL = `${API.INSERT_PRODUCT_URL}`
const response = await fetch(URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json', // 서버가 JSON 형식의 본문을 받도록 설정
        },
        body: JSON.stringify(requestDto)
    })

return response.json();
}