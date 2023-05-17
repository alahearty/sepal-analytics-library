module.exports = {
  content: [
    "./public/**/*.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  darkMode: "class",
  theme: {
    extend: {
      width: {
        sidebar: "350px",
        search: "400px",
      },
      rotate: {
        137: "137deg",
      },
      backgroundColor: {
        packed: "#EEF6FF",
      },
      colors: {
        primary: "#4F46E5",
      },
      fontFamily: {
        lexend: "'Lexend', sans-serif",
      },
    },
  },
  plugins: [],
};
