import { API } from "../config/config.js"

export async function deleteProductApi(requestDto) {
const URL = `${API.DELETE_PRODUCT_URL}`
const response = await fetch(URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json', // 서버가 JSON 형식의 본문을 받도록 설정
        },
        body: JSON.stringify(requestDto)
    })

return response.json();
}