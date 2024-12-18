package com.example.kiracuchat
import android.content.Intent
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.TextView
import androidx.activity.ComponentActivity
import java.io.BufferedReader
import java.io.IOException
import java.io.InputStream
import java.io.InputStreamReader
import java.net.HttpURLConnection
import java.net.URL


class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val userOptionBtn: Button = findViewById(R.id.user_option_btn)
        val channelBtn: Button = findViewById(R.id.channel_btn)

        userOptionBtn.setOnClickListener {
            startActivity(Intent(this, UserOptionActivity::class.java))
        }
        channelBtn.setOnClickListener {
            startActivity(Intent(this, channel::class.java))
        }

    }


    fun buttonOnClick(view: View){ // ①クリック時の処理を追加
        var response = getAPI()
        val textView: TextView = findViewById(R.id.textView)
        textView.text = response
    }

    fun getAPI(): String {
        var urlConnection: HttpURLConnection? = null
        var inputStream: InputStream? = null
        var response = ""

        try {
            val url = URL("https://192.168.40.125:7287/ConTest/ping")

            // 接続先URLへのコネクションを開く
            urlConnection = url.openConnection() as HttpURLConnection

            // 接続タイムアウトとレスポンスタイムアウトを設定
            urlConnection.connectTimeout = 10000  // 10秒
            urlConnection.readTimeout = 10000     // 10秒

            // ヘッダーにUser-AgentとAccept-Languageを設定
            urlConnection.addRequestProperty("User-Agent", "Android")
            urlConnection.addRequestProperty("Accept-Language","ja-JP" )

            // HTTPメソッドをGETに設定
            urlConnection.requestMethod = "GET"
            urlConnection.doOutput = false
            urlConnection.doInput = true

            // 接続を開始
            urlConnection.connect()

            // レスポンスコードを取得
            val statusCode = urlConnection.responseCode

            // レスポンスコードが200ならレスポンスを読み取る
            if (statusCode == 200) {
                // ストリームを使ってレスポンスを読み取る
                inputStream = urlConnection.inputStream
                val bufferedReader = BufferedReader(InputStreamReader(inputStream, "UTF-8"))

                // レスポンスボディを行単位で読み取る
                response = bufferedReader.use { it.readText() }
            }else{
                println("Error: Response code $statusCode")
                return "Error: Response code $statusCode"
            }
        } catch (e: IOException) {
            e.printStackTrace()
            return e.message.toString()
        } finally {
            // リソースを適切に解放
            urlConnection?.disconnect()
            inputStream?.close()
        }

        return response
    }



}
