import { parseISO, differenceInMilliseconds, parse } from "date-fns";
export default {
    setSession: function (authenticationResult) {
        window.localStorage.setItem("token", authenticationResult.token);
        window.localStorage.setItem("expireAt", authenticationResult.expireAt);
        window.localStorage.setItem("refreshToken", authenticationResult.refreshToken);
    },
    getToken: function () {
        return window.localStorage.getItem("token");
    },
    isAuthenticated: function () {
        var token = window.localStorage.getItem("token");
        if (!token) {
            return false;
        }
        var expireAt = window.localStorage.getItem("expireAt");
        let diff = differenceInMilliseconds(parseISO(expireAt), new Date());
        if (diff < 0) {
            return false;
        }
        return true;
    }
}