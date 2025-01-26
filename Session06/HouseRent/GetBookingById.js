import http from 'k6/http';
import { check } from 'k6';

export let options = {
    stages: [
        { duration: '1m', target: 10 },  // 10 کاربران همزمان
        { duration: '2m', target: 50 }, // افزایش به 50 کاربران
        { duration: '1m', target: 0 },  // کاهش به 0
    ],
};

export default function () {
    const res = http.get('https://localhost:7010/api/Bookings/1321100046858457088');
    check(res, {
        'response time < 200ms': (r) => r.timings.duration < 200,
    });
}
